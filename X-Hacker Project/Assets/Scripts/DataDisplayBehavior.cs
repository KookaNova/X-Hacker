using System;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayBehavior : MonoBehaviour
{
    public FloatDataSO floatData;
    public Text dataText;

    private void Update()
    {
        if (floatData.value < 1f)
        {
            dataText.text = "0";
        }
        else
        {
            dataText.text = floatData.value.ToString("####.##");
        }
    }
}