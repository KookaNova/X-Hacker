using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class CounterBehavior : MonoBehaviour
{
    [Header("Timer Values")] 
    public int StartValue = 0;
    public int MinValue = 0, MaxValue = 1000;
    public float WaitTime = 1;
    
    [Header("FloatData Values")]
    public FloatDataSO countedObj;
    public float changeAmount;

    [Header("Events")] 
    public UnityEvent OnCountEvent;
    public UnityEvent OnEndEvent;
    
    private int _value = 0;

    public void StartCounter()
    {
        _value = StartValue;
        StartCoroutine(RunCounter());
    }

    private IEnumerator RunCounter()
    {
        var waitObject = new WaitForSeconds(WaitTime);
        
        while (_value < MaxValue && _value > MinValue)
        {
            yield return waitObject;
            OnCountEvent.Invoke();
            _value++;
            UpdateData();
        }

        yield return waitObject;
        OnEndEvent.Invoke();
        //Idea is that the counter gets too high and you get fired a.k.a. you lose.
        //We would set the max really high though.
    }

    private void UpdateData()
    {
        countedObj.UpdateValue(changeAmount);
    }
    
    
}