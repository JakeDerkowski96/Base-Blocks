using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random1 : MonoBehaviour
{
    public static int randomValue = 0;
    public static int randomValue_Convert1 = 0;
    Text value;

    public void pushText()          //a random number is generated for the ten place and its value depends on the difficulty
                                    //due to base 5 the one place value depends on the 25 place value
    {
        if (SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("Random1").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(1, 5);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 5);
            }
            value.text = randomValue.ToString();
            randomValue_Convert1 = randomValue * 1;
            Random25.if_25_2 = false;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("Random1").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(1, 5);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 5);
            }
            value.text = randomValue.ToString();
            randomValue_Convert1 = randomValue * 1;
            Random25.if_25_2 = false;
        }
        else
        {
            value = GameObject.Find("Random1").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(1, 10);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 5);
            }
            value.text = randomValue.ToString();
            randomValue_Convert1 = randomValue * 1;
            Random25.if_25_2 = false;
        }        
    }

    private void Start()
    {
        if (SettingsScript.SliderValue < 1)
        {
            SettingsScript.SliderValue = 1;
        }
    }

    private void Update()
    {
        if (Random25.if_25_2 == true)
        {
            pushText();            
        }
    }
}
