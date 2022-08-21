using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody myRigidbody;
    
    [SerializeField]
    private float moveSpeed;

    private void FixedUpdate() 
    {
        var direction = new Vector3(TouchController.Instance.Direction.x, 0, TouchController.Instance.Direction.y);
        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        myRigidbody.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
