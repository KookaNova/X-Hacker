using UnityEngine;
using UnityEngine.Events;

public class EventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, fixedUpdateEvent;
    
    void Start()
    {
        startEvent.Invoke();
    }

    void FixedUpdate()
    {
        fixedUpdateEvent.Invoke();
    }
}