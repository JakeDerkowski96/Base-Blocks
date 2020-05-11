using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAdd1_B5 : MonoBehaviour
{

    public static int randomValue = 0;
    Text value;


    public void pushText()
    {
        if (SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("RandomAdd1").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(0, 3);
            value.text = randomValue.ToString();
        }
        else if (SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("RandomAdd1").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(5, 13);
            value.text = randomValue.ToString();
        }
        else
        {
            value = GameObject.Find("RandomAdd1").GetComponent<Text>();
            randomValue = UnityEngine.Random.Range(25, 63);
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
