using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text speakerDisplay, dialogueDisplay;
    public Image backgroundBox;
    public int currentTextIndex;
    public List<DialogueSO> dialogueToDisplay;
    private bool _speakerActive = false;

    private void Update()
    {
        if ( _speakerActive == true && Input.GetKeyDown("e"))
        {
            NextText();
        }
    }

    public void ChangeSpeaker()
    {
        _speakerActive = true;
        currentTextIndex = 0;
        dialogueDisplay.text = dialogueToDisplay[currentTextIndex].description;
        backgroundBox.gameObject.SetActive(true);
    }

    private void NextText()
    {
        currentTextIndex++;
        if (currentTextIndex >= dialogueToDisplay.Count)
        {
            
            _speakerActive = false;
            CloseText();
        }
        else
        {
            dialogueDisplay.text = dialogueToDisplay[currentTextIndex].description;
        }
    }

    private void CloseText()
    {
        currentTextIndex--;
        speakerDisplay.text = null;
        dialogueDisplay.text = null;
        backgroundBox.gameObject.SetActive(false);
        dialogueToDisplay[currentTextIndex].RunDialogueEvent();
    }




}
