using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScriptAdd10 : MonoBehaviour
{
    public static bool If_Restart = false;
    public static int RestartKnt = 0;

    public void Restart()
    {
        /*
            -upon pressing restart button, restartknt +1 and a bool value is sent to Manager script
             and the blocks are reset to try again
            -if after 3 tries the whold scene reset with a new random number and play session score 
             is decremented by 1
         */

        RestartKnt++;

        if(RestartKnt < 3)
        {
            If_Restart = true;
        }
        else
        {
            Add10Manager.A_B10_Score -= 1;
            RestartKnt = 0;
            AddScoreH.scoreValue = 0;
            AddScoreT.scoreValue3 = 0;
            AddScoreO.scoreValue2 = 0;
            SceneManager.LoadScene("AdditionB10Scene");
        }
    }
}
