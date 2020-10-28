using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task System/New Task")]
public class TaskDataSO : ScriptableObject
{
    [TextArea(15,20)] 
    public string description;
    public bool complete = false;
}
