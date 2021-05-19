﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] AudioClip spawnClip; // 出現時のAudioClip
    [SerializeField] AudioClip hitClip;   // 弾命中時のAudioClip

    // 倒された時に無効化するためにコライダーとレンダラーを持っておく
    [SerializeField] Collider enemyCollider; //コライダー

    AudioSource audioSource; //再生に使用するAudioSource

    private void Start()
    {
        // AudioSourceコンポーネントを取得しておく
        audioSource = GetComponent<AudioSource>();

        // 出現時の音を再生
        // PlayOneShotを使うことで、AudioClipを指定して再生できる
        audioSource.PlayOneShot(spawnClip);
    }

    // OnHitBulletメッセージから呼び出されることを想定
    public void OnHitBullet()
    {
        // 弾命中時の音を再生
        audioSource.PlayOneShot(hitClip);

        // 死亡処理
        GoDown();
    }


    void GoDown()
    {
        // 当たり判定と表示を消す（居なくなったように見せる）
        enemyCollider.enabled = false;
        gameObject.SetActive(false);

        // 自身のゲームオブジェクトを破棄（音が鳴った瞬間に削除しないように、1秒後の時間差で削除）
        Destroy(gameObject, 1f);
    }
}
