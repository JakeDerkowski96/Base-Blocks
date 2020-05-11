using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void NewNumber()     //when newgame button is pressed, a score value is added to play session depending on the difficulty
    {
        if(SettingsScript.SliderValue == 1)
        {
            Manager.I_B10_Score += 1;
        }
        else if(SettingsScript.SliderValue == 2)
        {
            Manager.I_B10_Score += 2;
        }
        else
        {
            Manager.I_B10_Score += 3;
        }
       
        Manager.winKnt = 0;         //block values and count values are reset for the scene to reload with a new random number
        Score.scoreValue = 0;
        Score2.scoreValue2 = 0;
        Score3.scoreValue3 = 0;
        SceneManager.LoadScene("BaseBlocks");
    }
}
