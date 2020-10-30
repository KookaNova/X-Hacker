using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ValueCompareSO : ScriptableObject
{
    public float comparedValue;
    public FloatDataSO valueData;
    public bool greaterThan, lessThan, equals;
    public UnityEvent greaterThanEvent, lessThanEvent, equalsEvent, greaterThanEqualsEvent, lessThanEqualsEvent;

    public void CompareValues()
    {
        if (greaterThan && lessThan)
        {
            Debug.LogError("You can't check for both greater and less than at the same time!");
            return;
        }

        if (greaterThan)
        {
            if (valueData.value > comparedValue)
            {
                greaterThanEvent.Invoke();

                if (equals)
                {
                    greaterThanEqualsEvent.Invoke();
                }
            }
        }

        if (lessThan)
        {
            if (valueData.value < comparedValue)
            {
                lessThanEvent.Invoke();

                if (equals)
                {
                    lessThanEqualsEvent.Invoke();
                }
            }
        }

        if (equals)
        {
            if (valueData.value == comparedValue)
            {
                equalsEvent.Invoke();
            }
        }
    }
}