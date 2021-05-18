using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 20f; // 弾速

    [SerializeField] ParticleSystem hitParticlePrefab;

    void Start()
    {
        // ゲームオブジェクト前方向の速度ベクトルを計算
        var velocity = speed * transform.forward;

        // Rigidbodyコンポーネントを取得
        var rigidbody = GetComponent<Rigidbody>();

        // Rigidbodyコンポーネントを使って初速を与える
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }

    // トリガー領域進入時に呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // 衝突対象に"OnHitBullet"メッセージ
        other.SendMessage("OnHitBullet");

        // 着弾地点に演出自動再生のゲームオブジェクトを生成
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);

        // 自身のゲームオブジェクト破棄
        Destroy(gameObject);
        
    }
}
