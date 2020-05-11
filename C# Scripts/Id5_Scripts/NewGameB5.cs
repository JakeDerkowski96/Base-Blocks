using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameB5 : MonoBehaviour
{
    public void NewNumber()     //when newgame button is pressed, a score value is added to play session depending on the difficulty
    {
        if (SettingsScript.SliderValue == 1)
        {
            LevelManagerBase5.I_B5_Score += 1;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            LevelManagerBase5.I_B5_Score += 2;
        }
        else
        {
            LevelManagerBase5.I_B5_Score += 3;
        }
        
        LevelManagerBase5.winKnt = 0;       //block values and count values are reset for the scene to reload with a new random number
        ScoreB5.scoreValueB5 = 0;
        ScoreB5_2.scoreValueB5_2 = 0;
        ScoreB5_3.scoreValueB5_3 = 0;
        SceneManager.LoadScene("BaseBlocksBase5");
    }
}
