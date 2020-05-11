using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random25 : MonoBehaviour
{
    public static int randomValue = 0;
    public static int randomValue_Convert25 = 0;
    Text value;
    public static bool if_25 = false;
    public static bool if_25_2 = false;

    public void pushText()          //a random number is generated for the hundred place and its value depends on the difficulty
    {
        if (SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("Random25").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 1);
            value.text = randomValue.ToString();
            randomValue_Convert25 = randomValue * 100;
            if_25 = true;
            if_25_2 = true;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("Random25").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 1);
            value.text = randomValue.ToString();
            randomValue_Convert25 = randomValue * 100;
            if_25 = true;
            if_25_2 = true;
        }
        else
        {
            value = GameObject.Find("Random25").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 2);
            value.text = randomValue.ToString();
            randomValue_Convert25 = randomValue * 100;
            if_25 = true;
            if_25_2 = true;
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
