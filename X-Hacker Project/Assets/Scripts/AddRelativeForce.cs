using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRelativeForce : MonoBehaviour
{
    public float force;
    private Rigidbody _rb;

    private void OnCollisionEnter(Collision obj)
    {
        _rb = obj.gameObject.GetComponent<Rigidbody>();
        _rb.AddRelativeForce(0,0,force);
        

    }
}
