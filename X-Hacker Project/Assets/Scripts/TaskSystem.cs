﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TaskSystem : MonoBehaviour
{
    public UnityEvent allTaskCompleteEvent;
    public List<TaskDataSO> taskList;
    
    private Text _taskText;
    private int _totalTasks;
    private int _completedTasks;

    public void Start()
    {
        _taskText = GetComponent<Text>();
        foreach (var t in taskList)
        {
            t.completedSteps = 0;
            t.complete = false;
        }

        _totalTasks = taskList.Count;
        CreateTaskList();
    }

    public void CreateTaskList()
    {
        _taskText.text = null;
        
        for (int i = 0; i < taskList.Count; i++)
        {
            
            //checks if all steps are complete
            if (taskList[i].completedSteps == taskList[i].totalSteps)
            {
                taskList[i].complete = true;
            }
            
            //checks if task is complete, updates completed task list accurately
            if (taskList[i].complete == true)
            {
                _completedTasks = 0;
                foreach (var j in taskList)
                {
                    if (j.complete == true)
                        _completedTasks++;

                }
                _taskText.text = _taskText.text + (i+1) + ". " + taskList[i].description + " COMPLETE " + "\n";

            }
            else
            {
                //checks amount of tasks needed to complete
                if (taskList[i].totalSteps > 1)
                {
                    _taskText.text = _taskText.text + (i+1) + ". " + taskList[i].description + " (" + taskList[i].completedSteps + "/" + taskList[i].totalSteps + ")" + "\n";
                }
                else
                _taskText.text = _taskText.text + (i+1) + ". " + taskList[i].description + "\n";
                
            }

            if ( _completedTasks == _totalTasks)
            {
                allTaskCompleteEvent.Invoke();
            }
        }
    }
}
