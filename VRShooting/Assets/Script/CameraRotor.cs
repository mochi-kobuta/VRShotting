using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotor : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f;
    float horaizontalAngle = 0f;
    float verticalAngle = 0f;


#if UNITY_EDITOR
    
    void Update()
    {
        // 入力による回転量取得
        var horaizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
        var verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;

        // 回転量を更新
        horaizontalAngle += horaizontalRotation;
        verticalAngle += verticalRotation;

        //垂直方向は回転しすぎないように制限
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);

        // transformコンポーネントに回転量を適用する
        transform.rotation = Quaternion.Euler(verticalAngle, horaizontalAngle, 0f);

    }
#endif

}
