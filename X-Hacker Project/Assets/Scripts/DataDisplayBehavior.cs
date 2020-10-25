using UnityEngine;
using UnityEngine.UI;

public class DataDisplayBehavior : MonoBehaviour
{
    public FloatDataSO floatData;
    public Text dataText;

    private void Update()
    {
        dataText.text = "" + floatData.value;
    }
}