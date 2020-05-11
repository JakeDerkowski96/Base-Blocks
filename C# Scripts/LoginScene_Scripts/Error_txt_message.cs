using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Error_txt_message : MonoBehaviour
{
    public static Text ErrorTxt;

    private void Start()    //on start sets connection to text input for text field
    {
        ErrorTxt = GetComponent<Text>();
    }
}
