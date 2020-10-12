using UnityEngine;
using UnityEngine.Events;

public class PauseBehavior : MonoBehaviour
{
    public UnityEvent pauseEvent, unpauseEvent;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        unpauseEvent.Invoke();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseEvent.Invoke();
    }
}