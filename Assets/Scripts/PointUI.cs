using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    Camera cam;
    public RectTransform uiTransform; // 対象UI(テキスト)のRectTransform

    public Vector3 worldTarget; // 出現させたいワールド座標

    public float displayTime = 1.0f; // 出現時間
    public float floatUpSpeed = 0.5f;  // 秒あたりの上昇スピード
    
    float timer;
    bool isShowing;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        timer = displayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowing)
        {
            return;
        }

        // Y方向に少しずつ上昇
        worldTarget += Vector3.up * floatUpSpeed * Time.deltaTime;

        // ワールド座標からUI座標に変換
        Vector3 screenPos = cam.WorldToScreenPoint(worldTarget);
        uiTransform.position = screenPos;

        // 時間経過で非表示
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            uiTransform.gameObject.SetActive(false);
            isShowing = false;
        }
    }

    public void Show(Vector3 worldPostion)
    {
        worldTarget = worldPostion;
        isShowing = true;
        uiTransform.gameObject.SetActive(true);
    }
}
