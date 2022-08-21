using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class ShootController : Singleton<ShootController>
{
    [SerializeField]
    private BulletController bulletPrefab;

    [SerializeField]
    private float delay;

    public float Delay => delay;
    public void Shoot(Vector3 direction,Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }

}
