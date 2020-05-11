using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{

    public static int scoreValue2 = 0;
    Text score2;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        score2 = GetComponent<Text>();
    }

    void Update()
    {
        score2.text = "" + scoreValue2;
    }
}
