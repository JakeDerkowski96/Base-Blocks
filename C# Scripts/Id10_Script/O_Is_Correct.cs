using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O_Is_Correct : MonoBehaviour
{
    Text CorrectO;

    private void Start()
    {
        CorrectO = GetComponent<Text>();
    }

    void Update()
    {
        if (Manager.O_Is_Correct == true)
        {
            CorrectO.text = "Ones Are Correct!";
        }
        else
            CorrectO.text = "";
    }
}
