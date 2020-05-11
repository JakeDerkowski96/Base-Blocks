using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class H_Is_Correct : MonoBehaviour
{
    Text CorrectH;

    private void Start()
    {
        CorrectH = GetComponent<Text>();
    }

    void Update()
    {
        if (Manager.H_Is_Correct == true)
        {
            CorrectH.text = "Hundreds Are Correct!";
        }
        else
            CorrectH.text = "";
    }
}
