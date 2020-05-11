using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Proyecto26;

public class MainMenuScript : MonoBehaviour
{
    TeacherUser User1 = new TeacherUser();      //class users are created to access the database
    TeacherUser T_User = new TeacherUser();
    StudentUser User2 = new StudentUser();
    StudentUser S_User = new StudentUser();

    public void ToPlayMenu()    //changes to gamemode scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }


    public void Settings()     //changes to score menu
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void OnQuit()       //exits the app
    {
        Application.Quit();
    }    

    public void Update()
    {
        /*
            -the following determines what kind of account is using the app: student, teacher, or guest
            -if either IsTeacherUser or IsStudentUser == true then database is accessed and users id is displayed
            -if both IsTeacherUser or IsStudentUSer == false then "Guest" is displayed
         */

        if (Login_Scene_Script.IsTeacherUser == true)
        {
            User1.TeacherID_3 = Login_Scene_Script.LoginId;            
            RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + User1.TeacherID_3 + ".json").Then(response =>
            {
                T_User = response;
            });
            ID_Text_Script.ID_text.text = T_User.TeacherID_3;   //displays to text field 
        }
        else if(Login_Scene_Script.IsStudentUser == true)
        {
            User2.StudentID_3 = Login_Scene_Script.LoginId;
            
            RestClient.Get<StudentUser>("https://blocks-b1047.firebaseio.com/" + User2.StudentID_3 + ".json").Then(response =>
            {
                S_User = response;                
            });
            ID_Text_Script.ID_text.text = "Hello " + S_User.StudentID_3;   //displays to text field           
        }
        else
        {
            ID_Text_Script.ID_text.text = "Hello Guest";
        }
       
    }

}
