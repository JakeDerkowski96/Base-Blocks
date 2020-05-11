using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreB5 : MonoBehaviour
{
    public static int scoreValueB5 = 0;
    public static int ScoreB5_Convert25 = 0;
    Text scoreB5;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        scoreB5 = GetComponent<Text>();
    }

    void Update()
    {
        scoreB5.text = "" + scoreValueB5;
        ScoreB5_Convert25 = scoreValueB5 * 25;  //multiplies the value to compare with random value
    }
}
