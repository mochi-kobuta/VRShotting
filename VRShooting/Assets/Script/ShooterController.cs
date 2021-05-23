using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] BulletGanarator bulletGanarator;
    BulletGanarator bGanarator;

    [SerializeField] ParticleSystem gunParticle; // 発射時演出

    [SerializeField] AudioSource gunAudioSource; // 発射音の音源

    [SerializeField] float bulletInterval = 0.05f; // 弾を発射する間隔

    private void Start()
    {
        this.bGanarator = bulletGanarator.GetComponent<BulletGanarator>();
    }

    void Update()
    {
        // 入力に応じて弾を発生する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // スマホ対応
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("スマホ　弾丸");
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

    //void OnEnable()
    //{
    //    // 2秒後に弾を連続で発射する
    //    Debug.Log("OnEnable");
    //    InvokeRepeating("Shoot", 2.0f, bulletInterval);
    //}

    //void OnDisable()
    //{
    //    // Shoot処理を停止する
    //    Debug.Log("OnDisable");
    //    CancelInvoke("Shoot");
    //}
}
