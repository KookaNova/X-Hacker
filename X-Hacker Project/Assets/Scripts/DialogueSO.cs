using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Task", menuName = "Dialogue System/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    [TextArea(10,15)] 
    public string description;

    public UnityEvent dialogueEvent;

    public void RunDialogueEvent()
    {
        dialogueEvent.Invoke();
    }
}