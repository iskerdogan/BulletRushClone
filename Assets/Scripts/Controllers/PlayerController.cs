using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlayerController : MyCharacterController
{
    private bool isShooting;
    private List<Transform> enemies = new List<Transform>();

    private void Update()
    {
        if (enemies.Count>0)
        {
            transform.LookAt(enemies[0]);
        }
    }

    private void FixedUpdate()
    {
        var direction = new Vector3(TouchController.Instance.Direction.x, 0, TouchController.Instance.Direction.y);
        Move(direction);
    }

    private void OnCollisionEnter(Collision other)
    {
        var enemy = other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Dead();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var enemy = other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            if (!enemies.Contains(other.transform)) enemies.Add(other.transform);
            AutoShoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemies.Remove(other.transform);
        }
    }

    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (enemies.Count > 0)
            {
                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                ShootController.Instance.Shoot(direction, transform.position);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(ShootController.Instance.Delay);
            }
            isShooting = false;
        }

        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());
        }
    }
    private void Dead()
    {
        Debug.Log("dead");
        Time.timeScale = 0;
    }
}
