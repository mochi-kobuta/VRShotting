using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGanarator : MonoBehaviour
{
    [SerializeField] GameObject  bulletPrefab;     // 弾のプレハブ
    [SerializeField] Transform gunBarrelEnd;  // 銃口

    [SerializeField] ParticleSystem gunParticle; // 発射時演出

    public void CreateBullet()
    {
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        // 発射時演出
        gunParticle.Play();
    }
}
