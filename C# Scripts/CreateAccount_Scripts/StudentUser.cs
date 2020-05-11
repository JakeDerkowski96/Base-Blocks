using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

/*
    -creates a class for a student
    -values include id, password, and game scores
    -optional teacher id is not working at the moment
 */

public class StudentUser    
{

    public string StudentID_3;
    public string StudentPassword_3;
    //public static string OptionalTeacherID_3;

    public int Identity_Base_10_Score;
    public int Identity_Base_5_Score;
    public int Addition_Base_10_Score;
    public int Addition_Base_5_Score;

    public StudentUser()    //relates the values to create_account_script
    {
        StudentID_3 = Create_Account_Script.StudentID_2;
        StudentPassword_3 = Create_Account_Script.StudentPassword_2;
        //OptionalTeacherID_3 = Create_Account_Script.OptionalTeacherID_2;

        Identity_Base_10_Score = Create_Account_Script.I10_Score;
        Identity_Base_5_Score = Create_Account_Script.I5_Score;
        Addition_Base_10_Score = Create_Account_Script.A10_Score;
        Addition_Base_5_Score = Create_Account_Script.A5_Score;
    }
}
