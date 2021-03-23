using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerBehaviour : MonoBehaviour
{
    public enum AIState{
        standing,
        random,
        following,
        traveling,
        finalPlace
    };

    [Tooltip("Indicates the current action of the AI.")]
    public AIState currentState = AIState.standing;
    private AIState previousState;
    [Tooltip("An empty gameobject should be placed here to give the character a transform to travel to once they've reached their destination")]
    public Transform finalDestination;
    public List<Transform> travelDestinations;
    public int currentTravelDestination;
    private NavMeshAgent _agent;
    private Transform followingDestination, defaultDestination;
    private bool _isLooking = false, _isFollowing = false;
    private float walkRadius = 10;

    public void Awake() {
        
        _agent = GetComponent<NavMeshAgent>();
        defaultDestination = gameObject.transform;
        _agent.SetDestination(defaultDestination.position);
        UpdateState();
    }

    public void ChangeState(string newState){
        switch(newState){
            case "standing":
                currentState = AIState.standing;
                break;
            case "random":
                currentState = AIState.random;
                break;
            case "following":
                currentState = AIState.following;
                break;
            case "travelling":
                currentState = AIState.traveling;
                break;
            case "finalPlace":
                currentState = AIState.finalPlace;
                break;
        }
        
    }
    private void OnTriggerEnter(Collider obj) {
        if(currentState == AIState.following || currentState == AIState.standing)
        followingDestination = obj.gameObject.transform;
        _isLooking = true;
    }
    private void OnTriggerExit(Collider obj) {
        _isLooking = false;
    }
    public void Update() {

        if (_isLooking == true){
            //NPC looks at target with X rotation locked. Simple lookat command fails here.
            var xRot = transform.rotation.eulerAngles.x;
            transform.LookAt(followingDestination);
            var rot = transform.rotation.eulerAngles;
            rot.x = xRot;
            
            transform.rotation = Quaternion.Euler(rot);
        }
        if(previousState != currentState){
            StopCoroutine(StateDelay());
            UpdateState();
        }
        if(_isFollowing == true){
            _agent.destination = followingDestination.position;
        }

        
    }

    private void UpdateState(){
        previousState = currentState;
        switch(currentState){
            case AIState.standing:
                _isFollowing = false;
                defaultDestination = gameObject.transform;
                _agent.destination = defaultDestination.position;
                StartCoroutine(StateDelay());
                break;

            case AIState.random:
                _isLooking = false;
                _isFollowing = false;
                Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
                Vector3 finalPosition = hit.position;
                _agent.destination = finalPosition;

                StartCoroutine(StateDelay());
                break;

            case AIState.following:
                _isFollowing = true;
                StartCoroutine(StateDelay());
                break;
            
            case AIState.traveling:
                _isFollowing = false;
                _agent.destination = travelDestinations[currentTravelDestination].position;
                StartCoroutine(StateDelay());

                break;

            case AIState.finalPlace:
                _isFollowing = false;
                _agent.destination = finalDestination.position;
                StartCoroutine(StateDelay());

                break;

        }
    }
    private IEnumerator StateDelay(){
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        UpdateState();
    }
}
