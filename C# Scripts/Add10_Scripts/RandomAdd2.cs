using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAdd2 : MonoBehaviour
{

    public static int randomValue = 0;
    Text value;

    public void pushText()      //a random number is generated for the ten place and its value depends on the difficulty
    {
        if (SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("RandomAdd2").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(1, 6);
            value.text = randomValue.ToString();
        }
        else if (SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("RandomAdd2").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(11, 51);
            value.text = randomValue.ToString();
        }
        else
        {
            value = GameObject.Find("RandomAdd2").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(101, 501);
            value.text = randomValue.ToString();
        }        
    }

    private void Start()
    {
        if (SettingsScript.SliderValue < 1)
        {
            SettingsScript.SliderValue = 1;
        }
        pushText();
    }
}
