using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))] 
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f, gravity = 1f;
    public UnityEvent movingEvent;
    private Vector3 _direction, movement; 
    private CharacterController _controller;
    private bool canMove;
 
    public void Start() 
    { 
        _controller = GetComponent<CharacterController>();
        canMove = true;
    } 
 
    public void Update() 
    {
        if (_controller.enabled && canMove)
        {
            _direction.x = Input.GetAxis("Horizontal"); 
            _direction.z = Input.GetAxis("Vertical"); 
 
            movement = new Vector3(_direction.x, 0, _direction.z); 
 
            if (movement != Vector3.zero) 
            { 
                transform.rotation = Quaternion.Slerp(transform.rotation, 
                    Quaternion.LookRotation(movement), 0.25f);
            }
         
            movement.y -= gravity * 9 * Time.deltaTime; 
            _controller.Move(movement * speed * Time.deltaTime);
        }
    }

    public void PlayerCanMove(bool value)
    {
        canMove = value;
    }
}