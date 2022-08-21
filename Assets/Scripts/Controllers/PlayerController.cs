using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerController : MyCharacterController
{
    private void FixedUpdate() 
    {
        var direction = new Vector3(TouchController.Instance.Direction.x, 0, TouchController.Instance.Direction.y);
        Move(direction);
    }

    private void OnCollisionEnter(Collision other) 
    {
        var enemy= other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        var enemy= other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            var direction = other.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            ShootController.Instance.Shoot(direction,transform.position);
        }    
    }
    private void Dead()
    {
        Debug.Log("dead");
        Time.timeScale = 0;
    }
}
