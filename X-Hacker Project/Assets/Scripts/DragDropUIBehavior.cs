using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class DragDropUIBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private BoxCollider collider;
    private bool dragging;

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    public void FixedUpdate()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData) //Lets us use the cursor on UI elements
    {
        dragging = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}