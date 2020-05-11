using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore5_5 : MonoBehaviour
{

    public static int scoreValue2 = 0;
    public static int scoreValue2_Convert = 0;
    Text score2;

    void Start()
    {
        score2 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score2.text = "" + scoreValue2;
        scoreValue2_Convert = scoreValue2 * 5;
    }
}
