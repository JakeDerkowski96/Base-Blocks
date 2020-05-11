using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomO : MonoBehaviour
{

    public static int randomValue = 0;
    Text value;

    public void pushText()      //a random number is generated for the one place, and is not dependent on difficulty
    {
        value = GameObject.Find("RandomO").GetComponent<Text>();        
        randomValue = UnityEngine.Random.Range(1, 10);
        value.text = randomValue.ToString();
    }

    private void Start()
    {
        pushText();
    }    
}
