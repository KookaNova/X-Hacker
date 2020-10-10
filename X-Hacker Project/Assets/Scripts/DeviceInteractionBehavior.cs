using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeviceInteractionBehavior : MonoBehaviour
{
    //Display mini-game
        //Instantiate mini-game UI

        private BoxCollider trigger;
        public IDSO playerID;
        private IDSO otherID;
        private IDBehavior otherIDBehavior;
        public bool playerInRange, deviceActive;

        public void Start()
        {
            trigger = GetComponent<BoxCollider>();
            trigger.isTrigger = true;
        }

        public void Update()
        {
            if (playerInRange && deviceActive)
            {
                if (Input.GetKeyDown(KeyCode.E)) //Player presses button to interact with device
                {
                    Debug.Log("Player was in range and pressed E");
                    Debug.Log("A mini-game would pop up right now");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            otherIDBehavior = other.GetComponent<IDBehavior>();
            if (otherIDBehavior == null) return; //If the object doesn't have an ID then stop
            otherID = otherIDBehavior.IDObj;
            CheckID();
        }

        private void OnTriggerExit(Collider other)
        {
            if (otherID != null)
            {
                otherID = null;
            }
            CheckID();
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