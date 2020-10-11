using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
public class DragDropUIBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private BoxCollider collider;
    private bool dragging;
    private Vector3 originalPosition;
    public bool xAxis, yAxis; //Any bool that is true can be dragged on that axis
    public float limitXMin, limitXMax, limitYMin, limitYMax; //these limit how far the object can be dragged in their respective axis, 0 means its original position

    public void Start()
    {
        collider = GetComponent<BoxCollider>();
        originalPosition = transform.position;
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
                transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, originalPosition.x + limitXMin, originalPosition.x + limitXMax), transform.position.y);
            }

            if (!xAxis && yAxis)
            {
                transform.position = new Vector2(transform.position.x, Mathf.Clamp(Input.mousePosition.y, originalPosition.y + limitYMin, originalPosition.y + limitYMax));
            }

            if (xAxis && yAxis)
            {
                transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, originalPosition.x + limitXMin, originalPosition.x + limitXMax), Mathf.Clamp(Input.mousePosition.y, originalPosition.y + limitYMin, originalPosition.y + limitYMax));
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