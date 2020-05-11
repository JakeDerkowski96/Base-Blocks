using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

/*
    -creates a class for a teacher
    -values include id, password, student id and student password
    -student id and password is not working at the moment
 */

public class TeacherUser
{

    public string TeacherID_3;
    public string TeacherPassword_3;
    public string T_StudentID_3;
    public string T_StudentPassword_3;

    
    public TeacherUser()    //relates the values to create_account_script
    {
        TeacherID_3 = Create_Account_Script.TeacherID_2;
        TeacherPassword_3 = Create_Account_Script.TeacherPassword_2;
        T_StudentID_3 = Create_Account_Script.T_StudentID_2;
        T_StudentPassword_3 = Create_Account_Script.T_StudentPassword_2;
    }
}
