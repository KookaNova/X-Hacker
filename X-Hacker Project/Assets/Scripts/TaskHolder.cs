using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TaskHolder : MonoBehaviour
{
    public List<TaskDataSO> taskList;
    public int totalCompleted = 0;
    public bool allTasksCompleted = false;
    private Text _taskText;

    public void Start()
    {
        _taskText = GetComponent<Text>();
        CreateTaskList();
    }

    private void CreateTaskList()
    {
        for (int i = 0; i <= taskList.Count; i++)
        {
            if (taskList[i].complete == true)
            {
                totalCompleted = totalCompleted + 1;
                _taskText.text = _taskText.text + i + ". " + taskList[i].description + " Complete " + "\n";
            }
            else
            {
                _taskText.text = _taskText.text + i + ". " + taskList[i].description + "\n";
            }

            if (totalCompleted == taskList.Count)
            {
                allTasksCompleted = true;
            }
            
        }
    }

}
