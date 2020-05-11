using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int scoreValue = 0;
    Text score;

    void Start()        //shows the current value of the blocks in a certain drop area
    {
        score = GetComponent<Text> ();   
    }
    
    void Update()
    {
        score.text = "" + scoreValue;        
    }
}
