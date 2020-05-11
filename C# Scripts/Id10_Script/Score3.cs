using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score3 : MonoBehaviour
{

    public static int scoreValue3 = 0;
    Text score3;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        score3 = GetComponent<Text>();
    }

    void Update()
    {
        score3.text = "" + scoreValue3;
    }
}
