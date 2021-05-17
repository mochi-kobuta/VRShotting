using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletGanarator;
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
        this.bGanarator.createBullet();
    }
}
