using System;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerBehavior : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    
    [Header("Info sent to Dialogue System")]
    public string speakerName;
    public List<DialogueSO> dialogueList;

    private void OnTriggerEnter(Collider player)
    {
        SendDialogue();
    }

    public void SendDialogue()
    {
        dialogueSystem.speakerDisplay.text = speakerName;
        dialogueSystem.dialogueToDisplay = dialogueList;
        dialogueSystem.ChangeSpeaker();
        
    }
}
