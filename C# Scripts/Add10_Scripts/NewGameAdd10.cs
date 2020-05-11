using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameAdd10 : MonoBehaviour
{
    public void NewNumber()     //when newgame button is pressed, a score value is added to play session depending on the difficulty
    {
        if (SettingsScript.SliderValue == 1)
        {
            Add10Manager.A_B10_Score += 1;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            Add10Manager.A_B10_Score += 2;
        }
        else
        {
            Add10Manager.A_B10_Score += 3;
        }
       
        Add10Manager.winKnt = 0;        //block values and count values are reset for the scene to reload with a new random number
        AddScoreO.scoreValue2 = 0;
        AddScoreT.scoreValue3 = 0;
        AddScoreH.scoreValue = 0;
        SceneManager.LoadScene("AdditionB10Scene");
    }
}
