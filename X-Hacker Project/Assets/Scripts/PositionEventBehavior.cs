using System;
using UnityEngine;
using UnityEngine.Events;

public class PositionEventBehavior : MonoBehaviour
{
    private Vector3 positionToReach;
    public bool greaterThan, lessThan, equalTo, xAxis, yAxis;
    public Vector3 offsetVector;
    public UnityEvent reachedPositionEvent;

    private void Start()
    {
        positionToReach = transform.position + offsetVector;
    }

    private void FixedUpdate()
    {
        if (equalTo)
        {
            if (xAxis)
            {
                if (transform.position.x == positionToReach.x)
                {
                    reachedPositionEvent.Invoke();
                }
            }

            if (yAxis)
            {
                if (transform.position.y == positionToReach.y)
                {
                    reachedPositionEvent.Invoke();
                }
            }
        }

        if (greaterThan)
        {
            if (xAxis)
            {
                if (transform.position.x > positionToReach.x)
                {
                    reachedPositionEvent.Invoke();
                }
            }

            if (yAxis)
            {
                if (transform.position.y > positionToReach.y)
                {
                    reachedPositionEvent.Invoke();
                }
            }
        }

        if (lessThan)
        {
            if (xAxis)
            {
                if (transform.position.x < positionToReach.x)
                {
                    reachedPositionEvent.Invoke();
                }
            }

            if (yAxis)
            {
                if (transform.position.y < positionToReach.y)
                {
                    reachedPositionEvent.Invoke();
                }
            }
        }
    }
}