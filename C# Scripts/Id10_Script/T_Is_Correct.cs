using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Is_Correct : MonoBehaviour
{
    Text CorrectT;

    private void Start()
    {
        CorrectT = GetComponent<Text>();
    }

    void Update()
    {
        if (Manager.T_Is_Correct == true)
        {
            CorrectT.text = "Tens Are Correct!";
        }
        else
            CorrectT.text = "";
    }
}
