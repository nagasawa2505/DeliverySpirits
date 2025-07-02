using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float startTime = 60.0f;
    public float displayTime; // UIと連動する残り時間
    float pastTime; // 経過時間
    bool isTimeOver;

    // Start is called before the first frame update
    void Start()
    {
        // まずは基準時間をセット
        displayTime = startTime;
        pastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // タイムオーバーなら何もしない
        if (isTimeOver)
        {
            return;
        }

        // 経過時間の算出
        pastTime += Time.deltaTime;
        displayTime = startTime - pastTime;

        // 残り時間が0のとき
        if (displayTime <= 0)
        {
            displayTime = 0;
            isTimeOver = true;
        }
    }
}
