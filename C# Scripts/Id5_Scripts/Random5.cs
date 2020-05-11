using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random5 : MonoBehaviour
{
    public static int randomValue = 0;
    public static int randomValue_Convert5 = 0;
    Text value;

    public void pushText()      //a random number is generated for the ten place and its value depends on the difficulty
                                //due to base 5 the five place value depends on the 25 place value
    {
        if (SettingsScript.SliderValue == 1)
        {
            value = GameObject.Find("Random5").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(0, 1);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 3);
            }
            value.text = randomValue.ToString();
            randomValue_Convert5 = randomValue * 10;
            Random25.if_25 = false;
        }
        else if (SettingsScript.SliderValue == 2)
        {
            value = GameObject.Find("Random5").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(0, 3);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 3);
            }
            value.text = randomValue.ToString();
            randomValue_Convert5 = randomValue * 10;
            Random25.if_25 = false;
        }
        else
        {
            value = GameObject.Find("Random5").GetComponent<Text>();
            if (Random25.randomValue == 0)    //base 5 range
            {
                randomValue = UnityEngine.Random.Range(0, 10);
            }
            else if (Random25.randomValue == 1)
            {
                randomValue = UnityEngine.Random.Range(0, 3);
            }
            value.text = randomValue.ToString();
            randomValue_Convert5 = randomValue * 10;
            Random25.if_25 = false;
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
        if(Random25.if_25 == true)
        {
            pushText();            
        }
    }
}
