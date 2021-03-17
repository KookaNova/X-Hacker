﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionButtonEvents : MonoBehaviour
{
    public UnityEvent interactionButtonEvent;
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            interactionButtonEvent.Invoke();
        }
    }
}
