using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task System/New Task")]
public class TaskDataSO : ScriptableObject
{
    [TextArea(10,10)] 
    public string description;
    
    public int completedSteps = 0, totalSteps = 1;
    public bool complete = false;
    
    public void SetValue (int amount)
    {
        completedSteps = amount;
    }

    public void IncrementValue()
    {
        completedSteps++;
    }

    public void BoolState(bool state)
    {
        complete = state;
    }
}
