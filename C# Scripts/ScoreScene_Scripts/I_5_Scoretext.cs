using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class I_5_Scoretext : MonoBehaviour
{
    public static Text I_5_Score;

    private void Start()
    {
        I_5_Score = GetComponent<Text>();
    }
}
