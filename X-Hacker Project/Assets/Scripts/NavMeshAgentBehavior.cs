using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehavior : MonoBehaviour
{

    public bool eventActive;
    public UnityEvent reachedDestinationEvent;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void SetDestination(Vector3SO loc)
    {
        agent.destination = loc.data;
    }

    public void activateBool(bool value)
    {
        eventActive = value;
    }

    public void Update()
    {
        if (eventActive && agent.remainingDistance <= 0.1f)
        {
            agent.destination = agent.transform.position;
            reachedDestinationEvent.Invoke();
        }
    }
}