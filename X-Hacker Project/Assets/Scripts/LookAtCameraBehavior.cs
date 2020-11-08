using UnityEngine;

public class LookAtCameraBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}