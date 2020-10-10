using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Mini-Games/Printer")]
public class PrinterMiniGame : MiniGameBase
{
    public Vector3SO cablePosition, originalPosition;
    public UnityEvent successEvent, resetEvent;
    
    public override void StartMiniGame()
    {
        Debug.Log("start printer mini game debug text");
    }

    public override void Success()
    {
        if (cablePosition.data.x > originalPosition.data.x + 200)
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
        Debug.Log("mini game reset");
        resetEvent.Invoke();
    }
}