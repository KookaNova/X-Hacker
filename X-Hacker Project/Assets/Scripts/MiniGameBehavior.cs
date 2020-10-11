using UnityEngine;
using UnityEngine.Events;

public class MiniGameBehavior : MonoBehaviour
{
    public MiniGameBase miniGame;
    public UnityEvent deactivateEvent;
    
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
        gameObject.SetActive(false);
    }
    
    public void DeactivateDevice()
    {
        deactivateEvent.Invoke();
    }
}