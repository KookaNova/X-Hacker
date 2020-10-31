using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Narriation : MonoBehaviour
{
    public GameObject narriationPanel;
    public Text narriationText;

    private List<string> texts = new List<string>();
  
    private int index = -1;





    private void Start()
    {
       
        narriationPanel.SetActive(false);
    }

    public void PlayNarriation(List<string> _text)
    {
        texts.AddRange(_text);
       

        SetNext();

       
    }

    private void SetNext()
    {
        index += 1;

        if (index > texts.Count - 1)
        {
            StopNarriaton();
            
        }
        else
        {
            PlayNext();
        }
    }

    private void PlayNext()
    {
      
        narriationText.text = texts[index];
    }

    private void StopNarriaton()
    {
        index = -1;
        CancelInvoke();
        texts.Clear();
        narriationPanel.SetActive(false);
    }
}
