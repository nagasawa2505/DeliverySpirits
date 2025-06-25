using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Vector3 diff;
    GameObject player;
    public float followSpeed;

    // �J�����̏����ʒu
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

    // Update����ɌĂяo�����
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        // ���`�⊮�ŃJ������ړI�̈ʒu�ɓ�����
        // ���ݒn�A�ړI�n�A���x
        transform.position = Vector3.Lerp(transform.position, player.transform.position - diff, followSpeed * Time.deltaTime);
    }
}
