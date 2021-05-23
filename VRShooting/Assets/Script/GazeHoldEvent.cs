using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GazeHoldEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // ボタンをタップする時間
    [SerializeField] float gazeTapTime;
    // ボタンをタップした時のイベント
    [SerializeField] UnityEvent onGazeHold;

    // ポインターがUI上にある時間
    float timer;
    // ポインターがUI上にあるか？
    bool isHover;

    // ポインターがUI領域に入った時のイベント処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        // タイマーを0に
        timer = 0.0f;

        // Hover状態へ
        isHover = true;

        Debug.Log("OnPointerEnter");
    }

    // ポインターがUI領域から出た時のイベント処理
    public void OnPointerExit(PointerEventData eventData)
    {
        // Hover状態解除
        isHover = false;

        Debug.Log("OnPointerExit");
    }

    void Update()
    {
        // Hover状態でなければ処理を行わない
        if(!isHover)
        {
            return;
        }

        // 経過時間
        timer += Time.deltaTime;

        if(gazeTapTime < timer)
        {
            // イベント実行
            onGazeHold.Invoke();
        }
    }
}
