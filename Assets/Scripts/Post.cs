using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PostType
{
    box1,
    box2,
    box3
}

public class Post : MonoBehaviour
{
    public PostType type;
    bool posted;
    public int getPoint = 50;
    public TextMeshProUGUI pointText;

    public PointUI pointUI; // ポイント表示UI制御

    public static int[] successCounts = { 0, 0, 0 };  // 配達成功数

    private void OnTriggerEnter(Collider other)
    {
        if (posted)
        {
            return;
        }

        switch (type)
        {
            case PostType.box1:
                if (other.gameObject.CompareTag("Box1"))
                {
                    PostComp(0);
                }
                break;
            case PostType.box2:
                if (other.gameObject.CompareTag("Box2"))
                {
                    PostComp(1);
                }
                break;
            case PostType.box3:
                if (other.gameObject.CompareTag("Box3"))
                {
                    PostComp(2);
                }
                break;
            default:
                break;
        }
    }

    void PostComp(int boxNum)
    {
        posted = true;

        // 箱別の配達成功数加算
        successCounts[boxNum]++;

        // ポイント加算
        GameController.stagePoints += getPoint;

        // ポイント表示
        pointUI.Show(transform.position + (Vector3.up * 1.5f));
        pointText.text = "+" + getPoint.ToString() + "PT!";

        Destroy(transform.parent.gameObject, 3.0f);
    }
}
