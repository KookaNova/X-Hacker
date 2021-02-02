using UnityEngine;
using UnityEngine.Events;

public class EventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, fixedUpdateEvent, triggerEnterEvent, triggerExitEvent;
    
    void Start()
    {
        startEvent.Invoke();
    }

    void FixedUpdate()
    {
        fixedUpdateEvent.Invoke();
    }

    void OnTriggerEnter()
    {
        triggerEnterEvent.Invoke();
    }
    void OnTriggerExit()
    {
        triggerExitEvent.Invoke();
    }
}