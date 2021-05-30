using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlideInOut : MonoBehaviour
{
    void Start()
    {
        // rectTransformの取得
        var rectTransform = GetComponent<RectTransform>();

        // DOTWeenのシーケンスを作成
        var sequence = DOTween.Sequence();

        // 画面右からスライドインさせる
        sequence.Append(rectTransform.DOMoveX(0.0f, 1.0f));

        // 画面左へスライドアウトさせる
        sequence.Append(rectTransform.DOMoveX(-1400.0f, 0.8f));


    }
}
