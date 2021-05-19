using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGanarator : MonoBehaviour
{
    [SerializeField] GameObject  bulletPrefab;     // 弾のプレハブ
    [SerializeField] Transform gunBarrelEnd;  // 銃口 

    public void CreateBullet()
    {
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);
    }
}
