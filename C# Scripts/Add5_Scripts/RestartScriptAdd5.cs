using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScriptAdd5 : MonoBehaviour
{
    public static bool If_Restart = false;
    public static int RestartKnt = 0;

    public void Restart()
    {
        RestartKnt++;

        if (RestartKnt < 3)
        {
            If_Restart = true;
        }
        else
        {
            Add5Manager.A_B5_Score -= 1;

            RestartKnt = 0;
            AddScore5_25.scoreValue = 0;
            AddScore5_5.scoreValue2 = 0;
            AddScore5_1.scoreValue3 = 0;
            SceneManager.LoadScene("AdditionB5Scene");
        }
    }

}
