using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Mini-Games/Computer")]
public class ComputerMiniGame : MiniGameBase
{
    public int buttonPresses;
    public UnityEvent successEvent, resetEvent;
    public override void StartMiniGame()
    {
        ResetCount();
    }

    public override void Success()
    {
        if (buttonPresses > 0)
        {
            successEvent.Invoke();
        }
    }

    public override void ResetMiniGame()
    {
        ResetCount();
        resetEvent.Invoke();
    }

    public void IncreaseCount()
    {
        buttonPresses++;
    }

    public void ResetCount()
    {
        buttonPresses = 0;
    }
}