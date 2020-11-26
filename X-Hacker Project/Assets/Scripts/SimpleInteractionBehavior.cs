using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class SimpleInteractionBehavior : MonoBehaviour
{
    public IDSO playerID;
    public bool playerInRange;
    public UnityEvent playerInRangeEvent, playerNotInRangeEvent, interactionEvent;

    private IDSO otherID;
    private IDBehavior otherIDBehavior;
    private BoxCollider trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
        trigger.isTrigger = true;
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E)) //Player presses button to interact with device
            {
                interactionEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        otherIDBehavior = other.GetComponent<IDBehavior>();
        if (otherIDBehavior == null) return; //If the object doesn't have an ID then stop
        otherID = otherIDBehavior.IDObj;
        CheckID();

        if (playerInRange)
        {
            playerInRangeEvent.Invoke();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (otherID != null)
        {
            otherID = null;
        }
        CheckID();

        //Is the player not in the trigger? Call the event if so
        if (!playerInRange)
        {
            playerNotInRangeEvent.Invoke();
        }
    }
    
    private void CheckID()
    {
        if (otherID == playerID)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
}