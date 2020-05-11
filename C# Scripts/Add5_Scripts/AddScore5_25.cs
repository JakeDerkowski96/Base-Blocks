using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore5_25 : MonoBehaviour
{

    public static int scoreValue = 0;
    public static int scoreValue_Convert = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;
        scoreValue_Convert = scoreValue * 25;
    }
}
