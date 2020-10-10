using UnityEngine;
using UnityEngine.Events;

public class MiniGameBehavior : MonoBehaviour
{
    public MiniGameBase miniGame;
    public UnityEvent deactivateEvent;
    
    public GameAction gameActionObj;
    public UnityEvent handlerEvent;
    
    public void OnEnable()
    {
        gameActionObj.action += Action;
        miniGame.StartMiniGame();
    }
    
    private void OnDisable()
    {
        gameActionObj.action -= Action;
    }

    private void Action()
    {
        handlerEvent.Invoke();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CloseMiniGame();
        }
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