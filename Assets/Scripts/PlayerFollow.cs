using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Vector3 diff;
    GameObject player;
    public float followSpeed;

    // カメラの初期位置
    public Vector3 defaultPos = new Vector3(0, 5, -8);
    public Vector3 defaultRotate = new Vector3(12, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(defaultRotate);

        player = GameObject.FindGameObjectWithTag("Player");
        diff = player.transform.position - transform.position;
    }

    // Updateより後に呼び出される
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        // 線形補完でカメラを目的の位置に動かす
        // 現在地、目的地、速度
        transform.position = Vector3.Lerp(transform.position, player.transform.position - diff, followSpeed * Time.deltaTime);
    }
}
