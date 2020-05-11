using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Proyecto26;


public class SettingsScript : MonoBehaviour
{
    TeacherUser User1 = new TeacherUser();
    TeacherUser T_User = new TeacherUser();
    StudentUser User2 = new StudentUser();
    StudentUser S_User = new StudentUser();

    public Slider Difficulty_Slider;
    public static float SliderValue;
    public PlayerPrefs SValue;

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void Start()
    {
        SliderValue = 1;
    }

    public void Update()
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

            ID_Text_Script.ID_text.text = T_User.TeacherID_3;

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

            ID_Text_Script.ID_text.text = "Hello " + S_User.StudentID_3;
            I_10_Scoretext.I_10_Score.text = "Identify Base 10 Score:    " + S_User.Identity_Base_10_Score.ToString();
            I_5_Scoretext.I_5_Score.text = "Identify Base 5 Score:      " + S_User.Identity_Base_5_Score.ToString();
            A_10_Scoretext.A_10_Score.text = "Addition Base 10 Score:   " + S_User.Addition_Base_10_Score.ToString();
            A_5_Scoretext.A_5_Score.text = "Addition Base 5 Score:     " + S_User.Addition_Base_5_Score.ToString();
        }
        else
        {
            ID_Text_Script.ID_text.text = "Guest";
        }

        
        SliderValue = Difficulty_Slider.value;
        //PlayerPrefs.GetFloat("SValue",SliderValue);
        //Debug.Log(SliderValue);
    }
}


