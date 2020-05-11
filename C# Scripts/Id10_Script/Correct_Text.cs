using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Correct_Text : MonoBehaviour
{
    Text CorrectMessage;
    public static bool Is_Correct = false;

    private void Start()
    {
        CorrectMessage = GetComponent<Text>();
    }

    void Update()
    {
        if (Manager.H_Is_Correct == true && Manager.T_Is_Correct == true &&
            Manager.O_Is_Correct == true)
        {
            Is_Correct = true;
            CorrectMessage.text = "Correct!";
        }
        else
            Is_Correct = false;
            CorrectMessage.text = "";
    }
}
