using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeakerBehavior : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    
    [Header("Info sent to Dialogue System")]
    public string speakerName;
    public List<DialogueSO> dialogueList;

    [Header("Trigger Events")]
    public UnityEvent enterEvent, exitEvent;


    private void OnTriggerEnter(Collider player)
    {
        enterEvent.Invoke();
    }
    private void OnTriggerExit(Collider player)
    {
         exitEvent.Invoke();
    }

    public void SendDialogue()
    {
        dialogueSystem.speakerDisplay.text = speakerName;
        dialogueSystem.dialogueToDisplay = dialogueList;
        dialogueSystem.ChangeSpeaker();
        
    }
}
