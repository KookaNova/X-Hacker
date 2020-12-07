using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseOverEventBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent triggerEnteredEvent, triggerExitedEvent;
    private Collider trigger;
    private bool triggerEntered;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Trigger Entered");
        if (!triggerEntered)
        {
            triggerEntered = true;
            triggerEnteredEvent.Invoke();
        }
    }

    public void ResetBool()
    {
        triggerEntered = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        triggerExitedEvent.Invoke();
    }
}