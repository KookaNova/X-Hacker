using UnityEngine;
using UnityEngine.Events;

public class MiniGameBehavior : MonoBehaviour
{
    public MiniGameBase miniGame;
    public UnityEvent deactivateEvent, closeMiniGameEvent;
    
    public void Start()
    {
        miniGame.StartMiniGame();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CloseMiniGame();
        }
    }

    public void FixedUpdate()
    {
        miniGame.Success();
    }

    public void CloseMiniGame()
    {
        miniGame.ResetMiniGame();
        closeMiniGameEvent.Invoke();
    }
    
    public void DeactivateDevice()
    {
        deactivateEvent.Invoke();
    }
}