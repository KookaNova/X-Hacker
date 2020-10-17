using System.Collections;
using UnityEngine;

public class CharControllerMovementDebug : MonoBehaviour
{
    private Vector3 originalPosition;
    private WaitForSeconds waitTime;
    public float controllerSpeed;

    private void Start()
    {
        waitTime = new WaitForSeconds(1f);
        StartCoroutine(CalculateSpeed());
    }

    private IEnumerator CalculateSpeed()
    {
        while (true)
        {
            originalPosition = transform.position;
            yield return waitTime;
            controllerSpeed = (transform.position - originalPosition).magnitude;
            Debug.Log(controllerSpeed);
        }
    }
}