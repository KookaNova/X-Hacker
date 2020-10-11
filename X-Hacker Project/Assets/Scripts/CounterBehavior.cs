using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterBehavior : MonoBehaviour
{

    public UnityEvent OnCountEvent, OnEndEvent;

    public int Value = 0, MaxValue = 1000;
    //1000 seconds is approximately 16 minutes to complete the objective. More than enough.
    public float WaitTime = 1;
    public FloatDataSO timeElapsed;

    public void StartCounter()
    {
        StartCoroutine(RunCounter());
    }

    private IEnumerator RunCounter()
    {
        var waitObject = new WaitForSeconds(WaitTime);
        
        while (Value > MaxValue)
        {
            yield return waitObject;
            OnCountEvent.Invoke();
            Value++;
            timeElapsed.UpdateValue(1);
        }

        yield return waitObject;
        OnEndEvent.Invoke();
        //Idea is that the counter gets too high and you get fired a.k.a. you lose.
        //We would set the max really high though.
    }
}