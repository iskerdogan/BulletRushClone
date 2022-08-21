using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 movement;
    private void FixedUpdate() 
    {
        transform.position += movement;
    }

    public void Fire(Vector3 direction)
    {
        movement = direction * Time.deltaTime * speed;
    }
}
