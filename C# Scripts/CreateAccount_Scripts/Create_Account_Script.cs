using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Proyecto26;

public class Create_Account_Script : MonoBehaviour
{
    TeacherUser user = new TeacherUser();
    StudentUser user2 = new StudentUser();
    public InputField StudentID;
    public InputField StudentPassword;
    public InputField StudentConfirmPassword;
    public InputField OptionalTeacherID;

    public InputField TeacherID;
    public InputField TeacherPassword;
    public InputField TeacherConfirmPassword;

    public static string StudentID_2;
    public static string StudentPassword_2;
    public static string StudentConfirmPassword_2;
    public static string OptionalTeacherID_2;
    public static int I10_Score = 0;
    public static int I5_Score = 0;
    public static int A10_Score = 0;
    public static int A5_Score = 0;

    public static string TeacherID_2;
    public static string TeacherPassword_2;
    public static string TeacherConfirmPassword_2;
    public static string T_StudentID_2;
    public static string T_StudentPassword_2;

    public static bool TeacherBool = false;
    public static bool StudentBool = false;
    public static bool OptionalBool = false;
    
    public static int ErrorCode;

    public static Text ErrorMessage;

    public void OnRegisterAccount()     //on register account button press
    {
        TeacherID_2 = TeacherID.text;                               //takes inputed fields values and sends to necessary values
        TeacherPassword_2 = TeacherPassword.text;
        TeacherConfirmPassword_2 = TeacherConfirmPassword.text;

        StudentID_2 = StudentID.text;
        StudentPassword_2 = StudentPassword.text;
        StudentConfirmPassword_2 = StudentConfirmPassword.text;
        OptionalTeacherID_2 = OptionalTeacherID.text;
        
        ErrorCode = 0;      //resets error code to no error

                /* - the following checks which fields are filled to determine if user is creating a student or teacher account
                   - then password and comfirm password are compared to match
                   - then a search of the database using inputed login ID is made to determine if account already exists
                   - if account doesnt already exists, account is created
                   - if at any point the logic fails, an error message is displayed */

        if (StudentID_2 == "" && TeacherID_2 != "" && TeacherPassword_2 != "" && TeacherConfirmPassword_2 != "")
        {
            if (TeacherConfirmPassword_2 == TeacherPassword_2)
            {
                RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + TeacherID_2 + ".json").Then(response =>
                {
                    user = response;
                });

                if (TeacherID_2 == user.TeacherID_3)
                {
                    TeacherBool = true;                  
                    ErrorCode = 1;  //user already exists error
                }
                else
                {
                    TeacherBool = false;                    
                }

                if(TeacherBool == false)
                {
                    PostTeacherToDatabase();                     
                    ErrorCode = 2;  //account created message                    
                }
            }
            else if(TeacherConfirmPassword_2 != TeacherPassword_2)
            {                   
                ErrorCode = 3;  //passwords do not match error
            }
        }
        else if(StudentID_2 != "" && TeacherID_2 == "" && StudentPassword_2 != "" && StudentConfirmPassword_2 != "")
        {
            if (StudentConfirmPassword_2 == StudentPassword_2)
            {
                        /* 
                            -if entered the optional teacher id will search for teacher accounts and make this account
                             a child of the already created teacher account.
                            -this does not work at the moment
                         */

                if(OptionalTeacherID_2 != "")
                {                    
                    RestClient.Get<TeacherUser>("https://blocks-b1047.firebaseio.com/" + user.TeacherID_3 + ".json").Then(response =>  //need to fix user.TeacherID_3 to tie to database
                    {
                        user = response;
                    });

                    if(OptionalTeacherID_2 == user.TeacherID_3)
                    {
                        OptionalBool = true;
                    }
                    else
                    {
                        OptionalBool = false;                        
                        ErrorCode = 4;  //teacher id doesnt exist error
                    }

                    if(OptionalBool == true) //posts the student as child under teacher
                    {
                        T_StudentID_2 = StudentID_2;
                        T_StudentPassword_2 = StudentPassword_2;
                        RestClient.Put("https://blocks-b1047.firebaseio.com/" + user.TeacherID_3 + ".json", user);
                    }
                }
                else    //if no optional teacher id is entered
                {
                    RestClient.Get<StudentUser>("https://blocks-b1047.firebaseio.com/" + StudentID_2 + ".json").Then(response =>
                    {
                        user2 = response;
                    });

                    if (StudentID_2 == user2.StudentID_3)
                    {
                        StudentBool = true;                        
                        ErrorCode = 1;  //user already exists error
                    }
                    else
                    {
                        StudentBool = false;
                    }

                    if (StudentBool == false)
                    {
                        PostStudentToDatabase();
                        ErrorCode = 2;  //account created message                        
                    }
                }               
            }
            else if(StudentConfirmPassword_2 != StudentPassword_2)
            {                
                ErrorCode = 3;  //passwords do not match error
            }
        }
        else
        {
            //failed logic if statements to determine error messages

            if (TeacherID_2 != "" && TeacherConfirmPassword_2 == "" && TeacherPassword_2 == "")
            {                
                ErrorCode = 6;  //password fields are empty error 
            }
            else if(TeacherID_2 != "" && (TeacherConfirmPassword_2 != "" || TeacherPassword_2 != ""))
            {
                ErrorCode = 3;  //passwords do not match error                
            }

            if (StudentID_2 != "" && StudentConfirmPassword_2 == "" && StudentPassword_2 == "")
            {               
                ErrorCode = 6;  
            }
            else if (StudentID_2 != "" && (StudentConfirmPassword_2 != "" || StudentPassword_2 != ""))
            {
                ErrorCode = 3;                
            }

            if (StudentID_2 == "" && TeacherID_2 == "")
            {               
                ErrorCode = 5;  //both id fields are empty error
            }
            else if (StudentID_2 != "" && TeacherID_2 != "")
            {                
                ErrorCode = 7;  //both id fields are filled error
            }           
        }
    }

    private void PostTeacherToDatabase()    //creates teacher account
    {
        TeacherUser user = new TeacherUser();
        RestClient.Put("https://blocks-b1047.firebaseio.com/" + TeacherID_2 + ".json", user);
    }

    private void PostStudentToDatabase()    //creates student account
    {
        StudentUser user2 = new StudentUser();
        RestClient.Put("https://blocks-b1047.firebaseio.com/" + StudentID_2 + ".json", user2);
    }

    public void BackToMenu()        //changes to login scene upon pressing Back button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
