using UnityEngine;
using UnityEngine.Events;

public class AnimationEventBehavior : MonoBehaviour
{
    public UnityEvent eventOne;

    public void CallEventOne()
    {
        eventOne.Invoke();
    }
}