using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnableTimer : MonoBehaviour
{
    public float seconds = 3;
    public UnityEvent enableEvent, countDownEvent;
    private void OnEnable()
    {
        enableEvent.Invoke();
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown(){
         yield return new WaitForSeconds(seconds);
         countDownEvent.Invoke();
    }
}
