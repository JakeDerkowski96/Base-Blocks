using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Proyecto26;

public class Add5Manager : MonoBehaviour
{
    public GameObject B25, B5, B1, MainArea;
    private GameObject TFClone, FClone, OClone;

    Vector2 InitialPos_25, InitialPos_5, InitialPos_1, TempPos_25, TempPos_5, TempPos_1;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    public Button Restart;
    public Button NewGame;

    public static int winKnt;
    public static int A_B5_Score;

    TeacherUser User1 = new TeacherUser();
    TeacherUser T_User = new TeacherUser();
    StudentUser User2 = new StudentUser();
    StudentUser S_User = new StudentUser();

    IEnumerator WaitTime()
    {
        Debug.Log("Started Couroutine at: " + Time.time);
        yield return new WaitForSecondsRealtime(1f);

        Debug.Log(S_User.Addition_Base_5_Score);
        S_User.Addition_Base_5_Score = S_User.Addition_Base_5_Score + A_B5_Score;

        if (S_User.Addition_Base_5_Score < 0)
        {
            S_User.Addition_Base_5_Score = 0;
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);
            Debug.Log(S_User.Addition_Base_5_Score);
        }
        else
        {
            RestClient.Put("https://blocks-b1047.firebaseio.com/" + S_User.StudentID_3 + ".json", S_User);
            Debug.Log(S_User.Addition_Base_5_Score);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        AddScore5_25.scoreValue = 0;
        AddScore5_5.scoreValue2 = 0;
        AddScore5_1.scoreValue3 = 0;
        A_B5_Score = 0;
        Debug.Log("Finished Couroutine at: " + Time.time);
    }

    public void BackToMenu()
    {
        if (Login_Scene_Script.IsTeacherUser == true)
        {
            User1.TeacherID_3 = Login_Scene_Script.LoginId;
            Debug.Log("User1:" + User1.TeacherID_3);
            RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + User1.TeacherID_3 + ".json").Then(response =>
            {
                T_User = response;
                Debug.Log("T_User:" + T_User.TeacherID_3);

            });

        }
        else if (Login_Scene_Script.IsStudentUser == true)
        {
            User2.StudentID_3 = Login_Scene_Script.LoginId;
            Debug.Log("User2:" + User2.StudentID_3);
            RestClient.Get<StudentUser>("https://blocks-b1047.firebaseio.com/" + User2.StudentID_3 + ".json").Then(response =>
            {
                S_User = response;
                Debug.Log("S_User:" + S_User.StudentID_3);
            });

            StartCoroutine(WaitTime());

        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
            AddScore5_25.scoreValue = 0;
            AddScore5_5.scoreValue2 = 0;
            AddScore5_1.scoreValue3 = 0;
            A_B5_Score = 0;            
        }        
    }

    private void Start()
    {        
        winKnt = 0;
        InitialPos_25 = B25.transform.position;
        InitialPos_5 = B5.transform.position;
        InitialPos_1 = B1.transform.position;
    }

    public void DragB25()
    {
        B25.transform.position = Input.mousePosition;
    }

    public void DragB5()
    {
        B5.transform.position = Input.mousePosition;
    }

    public void Drag1()
    {
        B1.transform.position = Input.mousePosition;
    }

    public void Drop25()
    {
        float Distance = Vector3.Distance(B25.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
            TempPos_25 = B25.transform.position;
            source.clip = correct[0];
            source.Play();
            AddScore5_25.scoreValue += 1;

            if (AddScore5_25.scoreValue < 9)
            {
                TFClone = Instantiate(B25, GameObject.Find("Canvas").transform, false);
                TFClone.transform.position = TempPos_25;
                B25.transform.position = InitialPos_25;
            }
        }
        else
        {
            B25.transform.position = InitialPos_25;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void Drop5()
    {
        float Distance = Vector3.Distance(B5.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
            TempPos_5 = B5.transform.position;
            source.clip = correct[0];
            source.Play();
            AddScore5_5.scoreValue2 += 1;

            if (AddScore5_5.scoreValue2 < 9)
            {
                FClone = Instantiate(B5, GameObject.Find("Canvas").transform, false);
                FClone.transform.position = TempPos_5;
                B5.transform.position = InitialPos_5;

            }
        }
        else
        {
            B5.transform.position = InitialPos_5;
            source.clip = incorrect;
            source.Play();
        }
    }

    public void Drop1()
    {
        float Distance = Vector3.Distance(B1.transform.position, MainArea.transform.position);
        if (Distance < 500)
        {
            TempPos_1 = B1.transform.position;
            source.clip = correct[0];
            source.Play();
            AddScore5_1.scoreValue3 += 1;

            if (AddScore5_1.scoreValue3 < 9)
            {
                OClone = Instantiate(B1, GameObject.Find("Canvas").transform, false);
                OClone.transform.position = TempPos_1;
                B1.transform.position = InitialPos_1;
            }
        }
        else
        {
            B1.transform.position = InitialPos_1;
            source.clip = incorrect;
            source.Play();
        }
    }

    public static int Base5Total;
    public static int Base5RandomTotal;

    public static bool Is_Correct = false;

    

    private void Update()
    {
        Debug.Log("WinKnt: " + winKnt);
        Base5Total = RandomAdd1_B5.randomValue + RandomAdd2_B5.randomValue;
        Base5RandomTotal = AddScore5_25.scoreValue_Convert + AddScore5_5.scoreValue2_Convert + AddScore5_1.scoreValue3_Convert;

        if (Base5Total == Base5RandomTotal)
        {
            //Is_Correct = true;
            NewGame.gameObject.SetActive(true);
            Restart.gameObject.SetActive(false);
            winKnt += 1;
            if (winKnt == 5)
            {
                source.clip = correct[1];
                source.Play();
                //winsound = false;
            }
            if (winKnt > 95)
            {
                winKnt = 0;
            }
        }
        else
        {
            //Is_Correct = false;
            NewGame.gameObject.SetActive(false);
            Restart.gameObject.SetActive(true);
        }

        if (RestartScriptAdd5.If_Restart == true)
        {
            AddScore5_25.scoreValue = 0;
            AddScore5_5.scoreValue2 = 0;
            AddScore5_1.scoreValue3 = 0;

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

            TempPos_25 = B25.transform.position;
            TempPos_5 = B5.transform.position;
            TempPos_1 = B1.transform.position;
            if (TempPos_25 != InitialPos_25)
            {
                B25.transform.position = InitialPos_25;
            }
            if (TempPos_5 != InitialPos_5)
            {
                B5.transform.position = InitialPos_5;
            }
            if (TempPos_1 != InitialPos_1)
            {
                B1.transform.position = InitialPos_1;
            }

            RestartScriptAdd5.If_Restart = false;
        }

    }
}
