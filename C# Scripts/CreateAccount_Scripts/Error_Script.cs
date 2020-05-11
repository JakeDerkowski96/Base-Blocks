using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error_Script : MonoBehaviour
{
    public static Text ErrorMessage;

    private void Start()    //on start sets connection to text input for text field
    {
        ErrorMessage = GetComponent<Text>();
    }

    private void Update()
    {       
        switch (Create_Account_Script.ErrorCode)       //displays error messages to the text field
        {
            case 1:
                ErrorMessage.text = "User Already Exists";
                break;
            case 2:
                ErrorMessage.text = "Account Created";
                break;
            case 3:
                ErrorMessage.text = "Passwords Do Not Match";
                break;
            case 4:
                ErrorMessage.text = "Teacher Id Doe Not Exist";
                break;
            case 5:
                ErrorMessage.text = "Both Id Fields Are Empty";
                break;
            case 6:
                ErrorMessage.text = "Password Fields Are Empty";
                break;
            case 7:
                ErrorMessage.text = "Both Id Fields are Filled";
                break;
        }
    }
}

