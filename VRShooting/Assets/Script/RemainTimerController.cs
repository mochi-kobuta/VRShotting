using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RemainTimerController : MonoBehaviour
{
    [SerializeField] float gameTime = 30.0f;      // ゲーム制限時間

    Text uiText;                                  // UIText コンポーネント
    float currentTime;                            // 残り時間タイマー
    [SerializeField] GameStateController state;   // ステート
    int nowState;

    void Start()
    {
        // Textコンポーネント取得
        uiText = GetComponent<Text>();

        // 残り時間を設定
        currentTime = gameTime;

        
    }

    void Update()
    {
        // ゲーム中のステートだったら処理続ける
        nowState = state.getCurrentState();
        if (nowState != (int)GameStateController.State.PlayingState)
        {
            return;
        }

        // 残り時間を計算
        currentTime -= Time.deltaTime;

        // 0秒以下にならない
        if(currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }

        // 残り時間テキスト更新
        uiText.text = string.Format("残り時間：{0:F}秒", currentTime);
        
    }

    // GameStateControllerで使用する
    public bool IsCountingDown()
    {
        // カウンターが0でなければ、カウント中
        return currentTime > 0.0f;
    }
}   
