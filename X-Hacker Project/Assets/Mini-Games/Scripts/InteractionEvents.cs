using UnityEngine;
using UnityEngine.Events;

public class InteractionEvents : MonoBehaviour
{
    public UnityEvent enterEvent, exitEvent;

    public void OnTriggerEnter()
    {
        enterEvent.Invoke();
    }

    public void OnTriggerExit()
    {
        exitEvent.Invoke();
    }

}
