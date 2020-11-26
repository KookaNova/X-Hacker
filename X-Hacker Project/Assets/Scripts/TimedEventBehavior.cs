using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEventBehavior : MonoBehaviour
{
    public float timer;
    public UnityEvent timedEvent;

    public void StartTimer()
    {
        StartCoroutine(InvokeEvent());
    }

    private IEnumerator InvokeEvent()
    {
        yield return new WaitForSeconds(timer);
        timedEvent.Invoke();
    }
}