using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore5_1 : MonoBehaviour
{

    public static int scoreValue3 = 0;
    public static int scoreValue3_Convert = 0;
    Text score3;

    void Start()
    {
        score3 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score3.text = "" + scoreValue3;
        scoreValue3_Convert = scoreValue3 * 1;
    }
}
