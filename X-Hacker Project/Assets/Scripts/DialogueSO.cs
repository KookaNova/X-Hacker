using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Dialogue System/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    [TextArea(10,15)] 
    public string description;
}