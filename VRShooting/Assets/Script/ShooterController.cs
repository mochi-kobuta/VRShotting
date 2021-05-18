using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] BulletGanarator bulletGanarator;
    BulletGanarator bGanarator;

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
    }
}
