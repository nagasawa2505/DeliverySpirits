using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // マウス感度
    float mouseSensitivity = 2f;

    // 上下の向きの範囲
    float minVerticalAngle = -20.0f;
    float maxVerticalAngle = 30.0f;

    // 左右の向きの範囲
    float minHorizontalAngle = -80f;
    float maxHorizontalAngle = 80f;

    // プレイ開始時の向き
    float verticalRotation = 0;
    float horizontalRotation = 0;

    // 左右の基準
    float initialY = 0;

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを画面の中心に固定
        Cursor.lockState = CursorLockMode.Locked;
        
        // カーソル非表示
        Cursor.visible = false;

        // 現在の向き
        Vector3 angles = transform.eulerAngles;
        initialY = angles.y;

        // カメラの向きを初期化
        horizontalRotation = 0f;
        verticalRotation = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // マウス入力取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 横方向
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle,maxHorizontalAngle);

        // 上を向くときはマイナス
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // 左右の基準点を考慮
        float yRotation = initialY + horizontalRotation;

        // カメラの向きを決定する
        transform.rotation = Quaternion.Euler(verticalRotation, yRotation, 0);
    }
}
