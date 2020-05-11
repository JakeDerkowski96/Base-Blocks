using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Proyecto26;

public class Manager : MonoBehaviour
{
    public GameObject Hundred, Ten, One, HundredArea, TenArea, OneArea;
    private GameObject HundredClone, TenClone, OneClone;

    Vector2 HundredInitialPos, TenInitialPos, OneInitialPos, TempHundredPos, TempTenPos, TempOnePos;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    public static bool H_Is_Correct = false;
    public static bool T_Is_Correct = false;
    public static bool O_Is_Correct = false;

    public Text Win;
    public Button Restart;
    public Button NewGame;

    public static int winKnt;
    public static int I_B10_Score;

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
        
        S_User.Identity_Base_10_Score = S_User.Identity_Base_10_Score + I_B10_Score;

        if(S_User.Identity_Base_10_Score < 0)
        {
            S_User.Identity_Base_10_Score = 0;
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);            
        }
        else
        {
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);            
        }       

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Score.scoreValue = 0;
        Score2.scoreValue2 = 0;
        Score3.scoreValue3 = 0;
        I_B10_Score = 0;        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Score.scoreValue = 0;
            Score2.scoreValue2 = 0;
            Score3.scoreValue3 = 0;
            I_B10_Score = 0;
        }

    }

    private void Start()        //on start block object positions are saved to an intial value
    {     
        winKnt = 0;
        HundredInitialPos = Hundred.transform.position;
        TenInitialPos = Ten.transform.position;
        OneInitialPos = One.transform.position;                      
    }
        
    public void DragHundred()       //when object is dragged the object's position is updated to users touch position
    {        
        Hundred.transform.position = Input.mousePosition;        
    }   

    public void DragTen()
    {
        Ten.transform.position = Input.mousePosition;
    }

    public void DragOne()
    {
        One.transform.position = Input.mousePosition;
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
        float Distance = Vector3.Distance(Hundred.transform.position, HundredArea.transform.position);
        if(Distance<300)
        {            
            TempHundredPos = Hundred.transform.position;
            source.clip = correct[0];
            source.Play();
            Score.scoreValue += 1;

            if(Score.scoreValue < 9)
            {
                HundredClone = Instantiate(Hundred, GameObject.Find("Canvas").transform, false);
                HundredClone.transform.position = TempHundredPos;
                Hundred.transform.position = HundredInitialPos;               
            }            
        }
        else
        {
            Hundred.transform.position = HundredInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void DropTen()
    {
        float Distance = Vector3.Distance(Ten.transform.position, TenArea.transform.position);
        if (Distance < 250)
        {
            TempTenPos = Ten.transform.position;
            source.clip = correct[0];
            source.Play();
            Score2.scoreValue2 += 1;

            if (Score2.scoreValue2 < 9)
            {
                TenClone = Instantiate(Ten, GameObject.Find("Canvas").transform, false);
                TenClone.transform.position = TempTenPos;
                Ten.transform.position = TenInitialPos;
            }            
        }
        else
        {
            Ten.transform.position = TenInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void DropOne()
    {
        float Distance = Vector3.Distance(One.transform.position, OneArea.transform.position);
        if (Distance < 250)
        {
            TempOnePos = One.transform.position;
            source.clip = correct[0];
            source.Play();
            Score3.scoreValue3 += 1;

            if (Score3.scoreValue3 < 9)
            {
                OneClone = Instantiate(One, GameObject.Find("Canvas").transform, false);
                OneClone.transform.position = TempOnePos;
                One.transform.position = OneInitialPos;
            }            
        }
        else
        {
            One.transform.position = OneInitialPos;
            source.clip = incorrect;
            source.Play();
        }
    }   
    
    
    void Update()
    {        
        
        if (Score.scoreValue == RandomH.randomValue)        //on each frame the value of each block is compared to the value of the random 
        {
            H_Is_Correct = true;            
        }
        else
            H_Is_Correct = false;

        if (Score2.scoreValue2 == RandomT.randomValue)
        {
            T_Is_Correct = true;            
        }
        else
            T_Is_Correct = false;

        if (Score3.scoreValue3 == RandomO.randomValue)
        {
            O_Is_Correct = true;            
        }
        else
            O_Is_Correct = false;

        if (Correct_Text.Is_Correct == true)    //once they are all equal the reset button disappears and a newgame button appears
        {                                       //also a win sound plays on a loop until the user moves on
            NewGame.gameObject.SetActive(true);
            Restart.gameObject.SetActive(false);            
            winKnt += 1;            
            if(winKnt == 1)
            {                
                source.clip = correct[1];
                source.Play();                
            }
            if(winKnt > 90)
            {
                winKnt = 0;
            }
        }
        else
        {            
            Win.gameObject.SetActive(false);
            NewGame.gameObject.SetActive(false);
            Restart.gameObject.SetActive(true);
        }

        /*
            -for the following:
            -if the user hits the reset button 3 times, the scene is reset with a new number
            -values get reset to 0, and all block clones are found and deleted
            then restartscript is activated to reset the scene
         */

        if(RestartScript.If_Restart == true)
        {
            Score.scoreValue = 0;
            Score2.scoreValue2 = 0;
            Score3.scoreValue3 = 0;

            foreach (GameObject Hundred in GameObject.FindGameObjectsWithTag("Block"))
            {
                if(Hundred.name == "Hundred(Clone)")
                {
                    Destroy(Hundred);
                }
            }

            foreach (GameObject Ten in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (Ten.name == "Ten(Clone)")
                {
                    Destroy(Ten);
                }
            }

            foreach (GameObject One in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (One.name == "One(Clone)")
                {
                    Destroy(One);
                }
            }

            TempHundredPos = Hundred.transform.position;
            TempTenPos = Ten.transform.position;
            TempOnePos = One.transform.position;
            if(TempHundredPos != HundredInitialPos)
            {
                Hundred.transform.position = HundredInitialPos;
            }
            if (TempTenPos != TenInitialPos)
            {
                Ten.transform.position = TenInitialPos;
            }
            if (TempOnePos != OneInitialPos)
            {
                One.transform.position = OneInitialPos;
            }

            RestartScript.If_Restart = false;            
        }
    }
}
