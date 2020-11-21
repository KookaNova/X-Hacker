using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Mini-Games/Printer")]
public class PrinterMiniGame : MiniGameBase
{
    public bool unplug, plugIn;
    public Vector3SO cablePosition, originalPosition;
    public UnityEvent successEvent, resetEvent;
    
    public override void StartMiniGame()
    {
        
    }

    public override void Success()
    {
        if (unplug)
        {
            if (cablePosition.data.x > originalPosition.data.x + 200)
            {
                successEvent.Invoke();
            }
        }

        if (plugIn)
        {
            if (cablePosition.data.x < originalPosition.data.x - 180)
            {
                successEvent.Invoke();
            }
        }
    }

    public override void ResetMiniGame()
    {
        Debug.Log("mini game reset");
        resetEvent.Invoke();
    }
}