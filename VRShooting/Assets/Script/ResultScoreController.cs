using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ResultScoreController : MonoBehaviour
{
    void Start()
    {
        // タグをつけたゲームオブジェクトの検索
        var gameObj = GameObject.FindWithTag("Score");
        // gameObjに含まれるScoreコンポーネントを取得
        var score = gameObj.GetComponent<ScoreController>();
        // Textコンポーネント取得
        var uiText = GetComponent<Text>();
        // 得点の更新
        // 残り時間テキスト更新
        uiText.text = string.Format("得点：{0:D3}点", score.Points);
    }
}
