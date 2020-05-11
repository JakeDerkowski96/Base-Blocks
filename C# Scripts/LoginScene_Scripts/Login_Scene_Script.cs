using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proyecto26;
using System;

public class Login_Scene_Script : MonoBehaviour
{
    public void GuestLogin()    //changes scene to main menu when guest login button pressed
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ToCreateAccount()   //changes scene to create account when create account button pressed
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    TeacherUser user = new TeacherUser();       // 2 student and teacher users created to store class
    TeacherUser T_user = new TeacherUser();     // values for comparison   

    StudentUser user2 = new StudentUser();
    StudentUser S_user = new StudentUser();    

    public InputField LoginIdField;
    public InputField LoginPasswordField;

    public static string LoginId;
    public static string LoginPassword;

    public static bool IsTeacherUser;
    public static bool IsStudentUser;

    private void Start()
    {
        IsTeacherUser = false;      //sets the student or teacher values to false at start
        IsStudentUser = false;         
    }

    IEnumerator WaitTime()      //wait function to pause the framerate to allow time for the app 
    {                           //and database to talk to each other
        
        yield return new WaitForSecondsRealtime(2f);        //waits 3 frame seconds

        if (LoginId == T_user.TeacherID_3 || LoginId == S_user.StudentID_3)     //compares the inputed login id and temp id
        {            
            if (LoginPassword == T_user.TeacherPassword_3 || LoginPassword == S_user.StudentPassword_3)     //if id matches, compares passwords
            {                   
                if (S_user.StudentID_3 == null)     //if matches and is a teacher account set teacher bool = true
                {
                    IsTeacherUser = true;                    
                }
                else if(T_user.TeacherID_3 == null)     //if matches and is a student account set student bool = true
                {
                    IsStudentUser = true;                    
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);   //changes scene to main menu
            }
            else    //output error message to error_txt_message script
            {
                Error_txt_message.ErrorTxt.text = "Password Not Found";                
            }
        }
        else     //output error message to error_txt_message script
        {
            Error_txt_message.ErrorTxt.text = "Account Not Found";           
        }         
    }

    public void Login()     //when login button is pressed
    {
        LoginId = LoginIdField.text;                //takes the user input and puts it in the necessary values
        LoginPassword = LoginPasswordField.text;

        user.TeacherID_3 = LoginId;
        user.TeacherPassword_3 = LoginPassword;
        user2.StudentID_3 = LoginId;
        user2.StudentPassword_3 = LoginPassword;        

            //the following takes the inputed login id and searches the database for a match
            //the response is then saved into a temperorary user

        if (LoginId != "" && LoginPassword != "")   // checks to make sure input fields are filled
        {
            RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + user.TeacherID_3 + ".json").Then(response =>
            {
                T_user = response;               
            });
            RestClient.Get<StudentUser>("https://blocks-b1047.firebaseio.com/" + user2.StudentID_3 + ".json").Then(response =>
            {
                S_user = response;                
            });

            StartCoroutine(WaitTime());     //calls a wait function       
        }
        else    //output error message to error_txt_message script
        {
            Error_txt_message.ErrorTxt.text = "Input Fields Are Empty";                        
        }
    }
}


  
