using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_5_Scoretext : MonoBehaviour
{
    public static Text A_5_Score;

    private void Start()
    {
        A_5_Score = GetComponent<Text>();
    }
}
