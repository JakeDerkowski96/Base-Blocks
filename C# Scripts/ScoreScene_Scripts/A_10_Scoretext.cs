using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_10_Scoretext : MonoBehaviour
{
    public static Text A_10_Score;

    private void Start()
    {
        A_10_Score = GetComponent<Text>();
    }
}
