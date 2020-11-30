using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
    public float rotationSpeed = 10;
    
    public void RotateOverTime(float degree)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime * rotationSpeed);
    }

    public void LookAtCamera()
    {
        transform.eulerAngles = Camera.main.transform.position;
    }
}