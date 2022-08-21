using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyCharacterController
{
    [SerializeField]
    private PlayerController player;
    private void FixedUpdate() 
    {
        var delta = player.transform.position - transform.position;
        delta.y = 0;
        var direction = delta.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }

}
