using UnityEngine;

public class LookAtCameraBehavior : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}