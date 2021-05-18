using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // OnHitBulletメッセージから呼び出されることを想定
    public void OnHitBullet()
    {
        // 自身のゲームオブジェクトを破棄
        Destroy(gameObject);
    }
}
