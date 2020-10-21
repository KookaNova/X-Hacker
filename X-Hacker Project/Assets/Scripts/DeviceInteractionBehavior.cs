using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class DeviceInteractionBehavior : MonoBehaviour
{
        private BoxCollider trigger;
        public IDSO playerID;
        private IDSO otherID;
        private IDBehavior otherIDBehavior;
        public bool playerInRange, deviceActive, miniGameActive;
        public UnityEvent interactionEvent;

        public GameAction gameActionObj;
        public UnityEvent handlerEvent;

        private void OnEnable()
        {
            gameActionObj.action += Action;
        }

        private void OnDisable()
        {
            gameActionObj.action -= Action;
        }

        private void Action()
        {
            if (miniGameActive)
            {
                handlerEvent.Invoke();
            }
        }
        
        //Functions above this line are for GameAction
        //The intent is that when the player completes a mini-game, the game will send a signal to listening
        //devices. Only devices with the miniGameActive bool set to true will hear the call. That bool is set to true
        //whenever the player interacts with a device that is active.
        //I could split this into two scripts but I don't see the issue with having it as one at the moment.
        // - Brandon

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
                    interactionEvent.Invoke(); //ENABLE A MINI-GAME IN THIS EVENT
                    miniGameActive = true;
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

        public void MiniGameDisable()
        {
            if (miniGameActive)
            {
                miniGameActive = false;
            }
        }
}