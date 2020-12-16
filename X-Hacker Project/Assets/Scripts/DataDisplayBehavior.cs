using System;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayBehavior : MonoBehaviour
{
    public enum ValueTypes
    {
        Integer,
        DecimalTwo,
        DecimalFour,
        Money
    };
    
    public ValueTypes valueType;
    
    public FloatDataSO floatData;
    public Text dataText;

    private void Update()
    {
        dataText.text = floatData.value < 1f ? "0" : floatData.value.ToString("####.##");

        switch (valueType)
        {
            case ValueTypes.Integer:
               dataText.text = floatData.value.ToString("####");
                break;
            
            case ValueTypes.DecimalTwo:
                dataText.text = floatData.value.ToString("####.##");
                break;
            
            case ValueTypes.DecimalFour:
                dataText.text = floatData.value.ToString("####.####");
                break;
            
            case ValueTypes.Money:
                dataText.text = "$" + floatData.value.ToString("####.##");
                break;
            
        }
    }
}