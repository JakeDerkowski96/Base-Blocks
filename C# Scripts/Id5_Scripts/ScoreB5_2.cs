using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreB5_2 : MonoBehaviour
{
    public static int scoreValueB5_2 = 0;
    public static int ScoreB5_Convert5 = 0;
    Text scoreB5_2;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        scoreB5_2 = GetComponent<Text>();
    }

    void Update()
    {
        scoreB5_2.text = "" + scoreValueB5_2;
        ScoreB5_Convert5 = scoreValueB5_2 * 5;      //multiplies the value to compare with random value

    }
}
