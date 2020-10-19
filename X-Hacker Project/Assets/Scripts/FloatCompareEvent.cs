using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatCompareEvent : MonoBehaviour
{
   public UnityEvent compareEvent;
   public FloatDataSO chosenData;
   public FloatDataSO comparedData;

   private void Update()
   {
      if (chosenData.value >= comparedData.value)
      {
         compareEvent.Invoke();
      }
   }
}
