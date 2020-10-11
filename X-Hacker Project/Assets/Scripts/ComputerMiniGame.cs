using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Mini-Games/Computer")]
public class ComputerMiniGame : MiniGameBase
{
    private int buttonPresses;
    public UnityEvent successEvent, resetEvent;
    public override void StartMiniGame()
    {
        Debug.Log("Computer mini-game started");
    }

    public override void Success()
    {
        if (buttonPresses > 0)
        {
            successEvent.Invoke();
        }
    }

    public override void Difficulty()
    {
        throw new System.NotImplementedException();
    }

    public override void ResetMiniGame()
    {
        buttonPresses = 0;
        resetEvent.Invoke();
    }

    public void IncreaseCount()
    {
        buttonPresses++;
    }
}