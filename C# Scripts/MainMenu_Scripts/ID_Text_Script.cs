using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ID_Text_Script : MonoBehaviour
{
    public static Text ID_text;   

    private void Start()    //on start sets connection to text input for text field
    {
        ID_text = GetComponent<Text>();
    }

   
}
