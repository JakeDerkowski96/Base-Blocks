using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameAdd5 : MonoBehaviour
{
    public void NewNumber()
    {
        if (SettingsScript.SliderValue == 1)
        {
            Add5Manager.A_B5_Score += 1;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            Add5Manager.A_B5_Score += 2;
        }
        else
        {
            Add5Manager.A_B5_Score += 3;
        }
        
        Add5Manager.winKnt = 0;
        AddScore5_25.scoreValue = 0;
        AddScore5_5.scoreValue2 = 0;
        AddScore5_1.scoreValue3 = 0;
        SceneManager.LoadScene("AdditionB5Scene");
    }
}
