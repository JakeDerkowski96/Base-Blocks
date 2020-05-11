using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreB5_3 : MonoBehaviour
{
    public static int scoreValueB5_3 = 0;
    public static int ScoreB5_Convert1 = 0;
    Text scoreB5_3;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        scoreB5_3 = GetComponent<Text>();
    }

    void Update()
    {
        scoreB5_3.text = "" + scoreValueB5_3;
        ScoreB5_Convert1 = scoreValueB5_3 * 1;      //multiplies the value to compare with random value

    }
}
