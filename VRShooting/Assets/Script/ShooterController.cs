using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] BulletGanarator bulletGanarator;
    BulletGanarator bGanarator;

    [SerializeField] ParticleSystem gunParticle; // 発射時演出

    [SerializeField] AudioSource gunAudioSource; // 発射音の音源

    private void Start()
    {
        this.bGanarator = bulletGanarator.GetComponent<BulletGanarator>();
    }

    void Update()
    {
        // 入力に応じて弾を発生する
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        // ジェネレータースクリプト弾を生成
        this.bGanarator.CreateBullet();

        // 発射時演出
        gunParticle.Play();

        // 発射時の音を再生
        gunAudioSource.Play();
    }
}
