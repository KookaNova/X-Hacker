using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{

    public Text textObj;
    public string correctCode = "1475";
    public int maxLength = 4;
    
    private string inputString;
    

    public UnityEvent incorrectEvent, correctEvent;

    private void Start()
    {
        inputString = "";
        UpdateText();
    }

    private void UpdateText()
    {
        textObj.text = inputString;
        if(inputString.Length == maxLength)
        {
            CodeCheck();
        }
    }

    public void AddText(string chars)
    {
        if (inputString.Length != maxLength)
        {
            inputString = inputString + chars;
            UpdateText();
        }
        
    }

    public void ClearText()
    {
        inputString = "";
        UpdateText();
    }

    private void CodeCheck()
    {
        if(inputString == correctCode)
        {
            StartCoroutine(CorrectReward());
        }
        else
        {
            StartCoroutine(IncorrectReward());
        }
    }
    
    private IEnumerator CorrectReward()
    {
        inputString = "VENDING";
        textObj.text = inputString;
        yield return new WaitForSeconds(2.5f);
        correctEvent.Invoke();
    }

    private IEnumerator IncorrectReward()
    {
        inputString = "WRONG";
        textObj.text = inputString;
        yield return new WaitForSeconds(2.5f);
        incorrectEvent.Invoke();
    }
}
