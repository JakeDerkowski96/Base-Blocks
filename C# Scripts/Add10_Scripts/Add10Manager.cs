using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Proyecto26;

public class Add10Manager : MonoBehaviour
{
    public GameObject Hundred, Ten, One, MainArea;
    private GameObject HundredClone, TenClone, OneClone;

    Vector2 HundredInitialPos, TenInitialPos, OneInitialPos, TempHundredPos, TempTenPos, TempOnePos;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;
    
    public Button Restart;
    public Button NewGame;

    public static int A_B10_Score;

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
        S_User.Addition_Base_10_Score = S_User.Addition_Base_10_Score + A_B10_Score;

        if (S_User.Addition_Base_10_Score < 0)
        {
            S_User.Addition_Base_10_Score = 0;
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);            
        }
        else
        {
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);           
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        AddScoreH.scoreValue = 0;
        AddScoreT.scoreValue3 = 0;
        AddScoreO.scoreValue2 = 0;
        A_B10_Score = 0;        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
            AddScoreH.scoreValue = 0;
            AddScoreT.scoreValue3 = 0;
            AddScoreO.scoreValue2 = 0;
            A_B10_Score = 0;
        }
    }

    private void Start()        //on start block object positions are saved to an intial value
    {
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
        float Distance = Vector3.Distance(Hundred.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
           TempHundredPos = Hundred.transform.position;
           source.clip = correct[0];
           source.Play();
           AddScoreH.scoreValue += 1;

            if (AddScoreH.scoreValue < 10)
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
        float Distance = Vector3.Distance(Ten.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
            TempTenPos = Ten.transform.position;
            source.clip = correct[0];
            source.Play();
            AddScoreT.scoreValue3 += 1;

            if (AddScoreT.scoreValue3 < 10)
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
        float Distance = Vector3.Distance(One.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
            TempOnePos = One.transform.position;
            source.clip = correct[0];
            source.Play();
            AddScoreO.scoreValue2 += 1;

            if (AddScoreO.scoreValue2 < 10)
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

    public static int Base10Total;
    public static int Base10RandomTotal;
    public static bool Is_Correct = false;
    public static int winKnt = 0;

    private void Update()       //on each frame the value of each block is compared to the value of the random 
    {
        Base10Total = RandomAdd1.randomValue + RandomAdd2.randomValue;
        Base10RandomTotal = AddScoreO.scoreValue2_Convert + AddScoreT.scoreValue3_Convert + AddScoreH.scoreValue_Convert;

        if(Base10Total == Base10RandomTotal)        //once they are all equal the reset button disappears and a newgame button appears
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

        if (RestartScriptAdd10.If_Restart == true)
        {
            AddScoreH.scoreValue = 0;
            AddScoreT.scoreValue3 = 0;
            AddScoreO.scoreValue2 = 0;

            foreach (GameObject Hundred in GameObject.FindGameObjectsWithTag("Block"))
            {
                if (Hundred.name == "Hundred(Clone)")
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
            if (TempHundredPos != HundredInitialPos)
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

            RestartScriptAdd10.If_Restart = false;
        }
    }
}
