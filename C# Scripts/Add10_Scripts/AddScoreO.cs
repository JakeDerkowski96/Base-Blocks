using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreO : MonoBehaviour
{
    public static int scoreValue2 = 0;
    public static int scoreValue2_Convert = 0;
    Text score2;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        score2 = GetComponent<Text>();
    }

    void Update()
    {
        score2.text = "" + scoreValue2;
        scoreValue2_Convert = scoreValue2 * 1;      //multiplies the value to compare with random value
    }
}
