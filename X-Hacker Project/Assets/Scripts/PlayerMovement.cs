using UnityEngine;

[RequireComponent(typeof(CharacterController))] 
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f, gravity = 1f;
    public Transform cameraTransform;
    private Vector3 _direction, movement; 
    private CharacterController _controller;
 
    public void Start() 
    { 
        _controller = GetComponent<CharacterController>();
        
    } 
 
    public void Update() 
    {
        if(_controller.enabled)
        {
            var currentFwd = cameraTransform.forward;
            var currentX = cameraTransform.right;

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");

            movement = (currentX * _direction.x) + (currentFwd * _direction.z);

            //controls look direction
            if (movement != Vector3.zero) 
            { 
                transform.forward = currentFwd;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 2f);
            }

        //actual movement
        movement.y -= gravity * 9 * Time.deltaTime; 
        _controller.Move(movement * speed * Time.deltaTime);

        }
    }
}