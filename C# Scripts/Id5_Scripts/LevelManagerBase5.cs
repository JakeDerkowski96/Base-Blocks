using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proyecto26;
using System;

public class LevelManagerBase5 : MonoBehaviour
{
    public GameObject TwentyFive, Five, Ones, TwentyFiveArea, FiveArea, OnesArea;
    private GameObject TwentyFiveClone, FiveClone, OnesClone;

    Vector2 TwentyFiveInitialPos, FiveInitialPos, OnesInitialPos, TempTwentyFivePos, TempFivePos, TempOnesPos;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    public static bool TF_Is_Correct = false;
    public static bool F_Is_Correct = false;
    public static bool Os_Is_Correct = false;
    public static bool Is_Correct = false;

    public static int TotalScore = 0;
    public static int TotalRandom = 0;

    public static int winKnt;
    public static int I_B5_Score;

    public Text Win;
    public Button Restart;
    public Button NewGame;

    TeacherUser User1 = new TeacherUser();
    TeacherUser T_User = new TeacherUser();
    StudentUser User2 = new StudentUser();
    StudentUser S_User = new StudentUser();

    /*
        -for the following:
        -once the user's gamemode score is retrieved it is added to the current play session score
        -if after adding the scores the player is now <0, then change the score to 0. this is so no player has a negative score
        -then the score is updated in the database and the scene is changed
      */

    IEnumerator WaitTime()
    {        
        yield return new WaitForSecondsRealtime(1f);
        
        S_User.Identity_Base_5_Score = S_User.Identity_Base_5_Score + I_B5_Score;

        if (S_User.Identity_Base_5_Score < 0)
        {
            S_User.Identity_Base_5_Score = 0;
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);            
        }
        else
        {
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);            
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        ScoreB5.scoreValueB5 = 0;
        ScoreB5_2.scoreValueB5_2 = 0;
        ScoreB5_3.scoreValueB5_3 = 0;
        I_B5_Score = 0;        
    }

    /*
        -for the following:
        -when user presses back button the database retrieves information based on if IsTeacherUser or IsStudentUser is true
        -the database returns the value of the game mode score and stores  it temp user
        -then a waittime function is called to give time for the database to send and recieve before the app continues on
        -if both IsTeacherUser and IsStudentUser is false then user is a guest, then no database call is made and the scene changes
     */

    public void BackToMenu()
    {
        if (Login_Scene_Script.IsTeacherUser == true)
        {
            User1.TeacherID_3 = Login_Scene_Script.LoginId;            
            RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + User1.TeacherID_3 + ".json").Then(response =>
            {
                T_User = response;
            });

        }
        else if (Login_Scene_Script.IsStudentUser == true)
        {
            User2.StudentID_3 = Login_Scene_Script.LoginId;            
            RestClient.Get<StudentUser>("https://blocks-b1047.firebaseio.com/" + User2.StudentID_3 + ".json").Then(response =>
            {
                S_User = response;               
            });
            StartCoroutine(WaitTime());           
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            ScoreB5.scoreValueB5 = 0;
            ScoreB5_2.scoreValueB5_2 = 0;
            ScoreB5_3.scoreValueB5_3 = 0;
            I_B5_Score = 0;
        }
    }

    private void Start()    //on start block object positions are saved to an intial value
    {
        winKnt = 0;
        TwentyFiveInitialPos = TwentyFive.transform.position;
        FiveInitialPos = Five.transform.position;
        OnesInitialPos = Ones.transform.position;
    }    

    public void DragHundred()   //when object is dragged the object's position is updated to users touch position
    {
        TwentyFive.transform.position = Input.mousePosition;
    }

    public void DragTen()
    {
        Five.transform.position = Input.mousePosition;
    }

    public void DragOne()
    {
        Ones.transform.position = Input.mousePosition;
    }

    /*
        -for the following:
        -when a block is dropped its distance to the center of a correct drop point is measured
        -if greater then the distance the block object is sent back to the intial position and a negative sound is played
        -if within the distance the block object is left where it was dropped and a positive sound is played, as well 
         as the value of the block is updated
        -after a successful drop, a clone of the block object is created to take the drop position while the original 
         is sent back to the intial position. this allows for an easier reset by deleting the clones.
      */

    public void DropHundred()
    {
        float Distance = Vector3.Distance(TwentyFive.transform.position, TwentyFiveArea.transform.position);
        if (Distance < 300)
        {            
            TempTwentyFivePos = TwentyFive.transform.position;            
            source.clip = correct[0];
            source.Play();
            ScoreB5.scoreValueB5 += 1;

            if (ScoreB5.scoreValueB5 < 4)
            {
                TwentyFiveClone = Instantiate(TwentyFive, GameObject.Find("Canvas").transform, false);
                TwentyFiveClone.transform.position = TempTwentyFivePos;
                TwentyFive.transform.position = TwentyFiveInitialPos;
            }
        }
        else
        {
            TwentyFive.transform.position = TwentyFiveInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void DropTen()
    {
        float Distance = Vector3.Distance(Five.transform.position, FiveArea.transform.position);
        if (Distance < 300)
        {
            TempFivePos = Five.transform.position;
            source.clip = correct[0];
            source.Play();
            ScoreB5_2.scoreValueB5_2 += 1;

            if (ScoreB5_2.scoreValueB5_2 < 4)
            {
                FiveClone = Instantiate(Five, GameObject.Find("Canvas").transform, false);
                FiveClone.transform.position = TempFivePos;
                Five.transform.position = FiveInitialPos;
            }
        }
        else
        {
            Five.transform.position = FiveInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void DropOne()
    {
        float Distance = Vector3.Distance(Ones.transform.position, OnesArea.transform.position);
        if (Distance < 300)
        {
            TempOnesPos = Ones.transform.position;
            source.clip = correct[0];
            source.Play();
            ScoreB5_3.scoreValueB5_3 += 1;

            if (ScoreB5_3.scoreValueB5_3 < 4)
            {
                OnesClone = Instantiate(Ones, GameObject.Find("Canvas").transform, false);
                OnesClone.transform.position = TempOnesPos;
                Ones.transform.position = OnesInitialPos;
            }
        }
        else
        {
            Ones.transform.position = OnesInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }

    

    void Update()
    {
        //on each frame the value of each block is compared to the value of the random 
        TotalScore = ScoreB5.ScoreB5_Convert25 + ScoreB5_2.ScoreB5_Convert5 + ScoreB5_3.ScoreB5_Convert1;
        TotalRandom = Random25.randomValue_Convert25 + Random5.randomValue_Convert5 + Random1.randomValue_Convert1;        

        if (TotalScore == TotalRandom)      //once they are all equal the reset button disappears and a newgame button appears,
        {
            Is_Correct = true;           
            NewGame.gameObject.SetActive(true);
            Restart.gameObject.SetActive(false);
            winKnt += 1;
            if (winKnt == 1)
            {
                source.clip = correct[1];       //also a win sound plays on a loop until the user moves on
                source.Play();               
            }
            if (winKnt > 90)
            {
                winKnt = 0;
            }
        }
        else
        {
            Is_Correct = false;
            NewGame.gameObject.SetActive(false);
            Restart.gameObject.SetActive(true);
        }

        /*
            -for the following:
            -if the user hits the reset button 3 times, the scene is reset with a new number
            -values get reset to 0, and all block clones are found and deleted
            then restartscript is activated to reset the scene
         */

        if (RestartScript5.If_Restart == true)
        {
            ScoreB5.scoreValueB5 = 0;
            ScoreB5_2.scoreValueB5_2 = 0;
            ScoreB5_3.scoreValueB5_3 = 0;

            foreach (GameObject TwentyFive in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (TwentyFive.name == "TwentyFive(Clone)")
                {
                    Destroy(TwentyFive);
                }
            }

            foreach (GameObject Five in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (Five.name == "Five(Clone)")
                {
                    Destroy(Five);
                }
            }

            foreach (GameObject Ones in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (Ones.name == "Ones(Clone)")
                {
                    Destroy(Ones);
                }
            }

            TempTwentyFivePos = TwentyFive.transform.position;
            TempFivePos = Five.transform.position;
            TempOnesPos = Ones.transform.position;
            if (TempTwentyFivePos != TwentyFiveInitialPos)
            {
                TwentyFive.transform.position = TwentyFiveInitialPos;
            }
            if (TempFivePos != FiveInitialPos)
            {
                Five.transform.position = FiveInitialPos;
            }
            if (TempOnesPos != OnesInitialPos)
            {
                Ones.transform.position = OnesInitialPos;
            }

            RestartScript5.If_Restart = false;
        }
    }
}
