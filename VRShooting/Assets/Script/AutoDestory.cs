using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour
{

    [SerializeField] float lifetime = 5f; // ゲームオブジェクトの寿命

    void Start()
    {
        // 一定時間経過後にゲームオブジェクトを破棄する
        Destroy(gameObject, lifetime);
    }
}
