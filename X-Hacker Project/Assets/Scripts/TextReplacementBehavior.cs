using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextReplacementBehavior : MonoBehaviour
{
    public Text textObj;

    public void ReplaceText(FloatDataSO data)
    {
        if (textObj)
        {
            textObj.text = data.value.ToString();
        }
    }
}