using UnityEngine;
using UnityEngine.Events;

public class EventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, fixedUpdateEvent, triggerEnterEvent, triggerExitEvent, colliderEnterEvent, colliderExitEvent;
    
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
    void OnCollisionEnter(Collision other) {
        colliderEnterEvent.Invoke();
    }
    void OnCollisionExit(Collision other) {
        colliderExitEvent.Invoke();
    }
}