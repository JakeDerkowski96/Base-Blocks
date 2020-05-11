using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomH : MonoBehaviour
{

    public static int randomValue = 0;
    Text value;    

    public void pushText()          //a random number is generated for the hundred place and its value depends on the difficulty
    {
        if(SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("RandomH").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 1);
            value.text = randomValue.ToString();
        }
        else if(SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("RandomH").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 1);
            value.text = randomValue.ToString();
        }
        else
        {
            value = GameObject.Find("RandomH").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(1, 10);
            value.text = randomValue.ToString();
        }        
    }

    private void Start()        
    {
        if(SettingsScript.SliderValue < 1)
        {
            SettingsScript.SliderValue = 1;
        }
        pushText();
    }    
   
}
