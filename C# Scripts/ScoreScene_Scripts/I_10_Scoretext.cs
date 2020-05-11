using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class I_10_Scoretext : MonoBehaviour
{
    public static Text I_10_Score;

    private void Start()
    {
        I_10_Score = GetComponent<Text>();
    }
}
