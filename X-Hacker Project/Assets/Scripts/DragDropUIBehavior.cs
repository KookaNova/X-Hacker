using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropUIBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    private Vector3 originalPosition;
    private Vector2 offset, curResolution;
    public bool xAxis, yAxis; //Any bool that is true can be dragged on that axis
    public float xMinLimit = 1, xMaxLimit = 1, yMinLimit = 1, yMaxLimit = 1;
    private float limitXMin, limitXMax, limitYMin, limitYMax; //these limit how far the object can be dragged in their respective axis, 0 means its original position

    
    /*
     * what is the screen (window) height and width?
     * origin of object
     * how much room it has to move in each direction from origin point
     * x = screen.width - origin.x
     * factor in limits
     */

    public void Start()
    {
        originalPosition = transform.position;
        FindScreenLimits();
    }

    public void OnDisable()
    {
        dragging = false;
    }

    public void FixedUpdate()
    {
        FindScreenLimits();
        if (dragging)
        {
            //Only move in X axis
            if (xAxis && !yAxis)
            {
                transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - offset.x, originalPosition.x + limitXMin, originalPosition.x + limitXMax), transform.position.y);
            }
            else if (!xAxis && yAxis) //Only move in Y axis
            {
                transform.position = new Vector2(transform.position.x, Mathf.Clamp(Input.mousePosition.y - offset.y, originalPosition.y + limitYMin, originalPosition.y + limitYMax));
            }
            else if (xAxis && yAxis) //Move in both axes
            {
                transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - offset.x, originalPosition.x + limitXMin, originalPosition.x + limitXMax), Mathf.Clamp(Input.mousePosition.y - offset.y, originalPosition.y + limitYMin, originalPosition.y + limitYMax));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData) //Lets us use the cursor on UI elements
    {
        dragging = true;
        offset.x = Input.mousePosition.x - transform.position.x;
        offset.y = Input.mousePosition.y - transform.position.y;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

    private void FindScreenLimits()
    {
        //Take current resolution and find the position of the object in that space
        curResolution = new Vector2(Screen.width, Screen.height);
        var xMax = curResolution.x - originalPosition.x;
        var xMin = -originalPosition.x;
        var yMax = curResolution.y - originalPosition.y;
        var yMin = -originalPosition.y;

        if (xMaxLimit != 0)
        {
            limitXMax = xMax / xMaxLimit;
        }

        if (xMinLimit != 0)
        {
            limitXMin = xMin / xMinLimit;
        }

        if (yMaxLimit != 0)
        {
            limitYMax = yMax / yMaxLimit;
        }

        if (yMinLimit != 0)
        {
            limitYMin = yMin / yMinLimit;
        }
    }
}