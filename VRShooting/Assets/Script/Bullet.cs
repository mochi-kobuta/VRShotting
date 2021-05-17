using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f; // 弾速

    void Start()
    {
        // ゲームオブジェクト前方向の速度ベクトルを計算
        var velocity = speed * transform.forward;

        // Rigidbodyコンポーネントを取得
        var rigidbody = GetComponent<Rigidbody>();

        // Rigidbodyコンポーネントを使って初速を与える
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }
}
