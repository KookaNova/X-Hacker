using UnityEngine;
[CreateAssetMenu]
public class FloatDataSO : ScriptableObject
{
    public float value;
   
    public void SetValue (float amount)
    {
        value = amount;
    }
   
    public void UpdateValue(float amount)
    {
        value += amount;
    }
   
    public void IncrementValue()
    {
        value ++;
    }
   
    public void UpdateValue(FloatDataSO data)
    {
        var newData = data as FloatDataSO;
        if (newData != null) value += newData.value;
    }

    public void SetValue(FloatDataSO data)
    {
        var newData = data as FloatDataSO;
        if (newData != null) value = newData.value;
    }
    
    public void CheckMinValue(float minValue)
    {
        if (value <= minValue)
        {
            value = minValue;
        }
    }

    public void CheckMaxValue(float maxValue)
    {
        if (value >= maxValue)
        {
            value = maxValue;
        }
    }
}