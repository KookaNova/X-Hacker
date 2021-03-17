using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerBehaviour : MonoBehaviour
{
    [Tooltip("An empty gameobject should be placed here to give the character a transform to travel to once they've reached their destination")]
    public Transform finalDestination;
    private NavMeshAgent _agent;
    private Transform followingDestination, defaultDestination;
    private bool _isLooking = false, _isFollowing = false;

    public void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        defaultDestination = gameObject.transform;
        _agent.SetDestination(defaultDestination.position);
    }
    
    private void OnTriggerEnter(Collider obj) {
        followingDestination = obj.gameObject.transform;
        _isLooking = true;
    }
    private void OnTriggerExit(Collider obj) {
        _isLooking = false;
    }
    public void Update() {
        if(_isLooking == true){
            //NPC looks at target with X rotation locked.
            var xRot = transform.rotation.eulerAngles.x;
            transform.LookAt(followingDestination);
            var rot = transform.rotation.eulerAngles;
            rot.x = xRot;
            
            transform.rotation = Quaternion.Euler(rot);
        }
        if(_isFollowing == true){
            _agent.destination = followingDestination.position;
        }
    }

    public void FollowCommand(){
        _isFollowing = true;
        _isLooking = false;
    }
    public void CancelFollow(){
        Debug.Log("Cancel Follow");
        _agent.destination = finalDestination.position;
        _isFollowing = false;
        _isLooking = true;
    }
}
