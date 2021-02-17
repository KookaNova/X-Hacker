using UnityEngine;
using UnityEngine.Events;

public class UITriggerEvents : MonoBehaviour
{
    public UnityEvent startEvent, awakeEvent, enterEvent, exitEvent;

    void Start()
    {
        startEvent.Invoke();
    }

    void Awake()
    {
        awakeEvent.Invoke();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enterEvent.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        exitEvent.Invoke();
    }
}
