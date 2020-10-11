using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class DragDropUIBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private BoxCollider collider;
    private bool dragging;
    public bool xAxis, yAxis; //Any bool that is true can be dragged on that axis

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    public void OnDisable()
    {
        dragging = false;
    }

    public void FixedUpdate()
    {
        if (dragging)
        {
            if (xAxis && !yAxis)
            {
                transform.position = new Vector2(Input.mousePosition.x, transform.position.y);
            }

            if (!xAxis && yAxis)
            {
                transform.position = new Vector2(transform.position.x, Input.mousePosition.y);
            }

            if (xAxis && yAxis)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
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