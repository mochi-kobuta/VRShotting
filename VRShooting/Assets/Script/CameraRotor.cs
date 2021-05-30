using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraRotor : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f;
    [SerializeField] float angularVelocity_sp = 2.0f;
    float horaizontalAngle = 0f;
    float verticalAngle = 0f;
    Vector2 startPos;
    float speed = 0;

    void Update()
    {
        // 入力による回転量取得
        float horaizontalRotation = 0.0f;
        float verticalRotation = 0.0f;

        // スマホでスワイプできる様にする
        if ((Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.Android) && !XRSettings.enabled))
        {

            if (Input.GetMouseButtonDown(0))
            {
                // マウスをクリックした位置
                this.startPos = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                // マウス押した位置と離した位置の差でスワイプを実現する
                Vector2 endPos = Input.mousePosition;
                float swipeLengthX = endPos.x - startPos.x;
                float swipeLengthY = endPos.y - startPos.y;

                horaizontalRotation = swipeLengthX * Time.deltaTime * angularVelocity_sp;
                verticalRotation = swipeLengthY * Time.deltaTime * angularVelocity_sp;
            }

        } else {
            horaizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
            verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;
        }

        // 回転量を更新
        horaizontalAngle += horaizontalRotation;
        //Debug.Log(horaizontalAngle);
        verticalAngle += verticalRotation;
        //Debug.Log(verticalAngle);

        //垂直方向は回転しすぎないように制限
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);

        // transformコンポーネントに回転量を適用する
        transform.rotation = Quaternion.Euler(verticalAngle, horaizontalAngle, 0f);

    }

}
