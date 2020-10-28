using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TaskHolder : MonoBehaviour
{
    public List<TaskDataSO> taskList;
    public int totalCompleted;
    public bool allTasksCompleted = false;
    private Text _taskText;

    public void Start()
    {
        _taskText = GetComponent<Text>();
        foreach (var t in taskList)
        {
            t.completedSteps = 0;
            t.complete = false;
        }
        
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
            
            //checks if task is complete
            if (taskList[i].complete == true)
            {
                totalCompleted = totalCompleted + 1;
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

            if (totalCompleted == taskList.Count)
            {
                allTasksCompleted = true;
            }
        }
    }
}
