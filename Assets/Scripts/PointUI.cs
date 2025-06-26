using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    Camera cam;
    public RectTransform uiTransform; // �Ώ�UI(�e�L�X�g)��RectTransform

    public Vector3 worldTarget; // �o�������������[���h���W

    public float displayTime = 1.0f; // �o������
    public float floatUpSpeed = 0.5f;  // �b������̏㏸�X�s�[�h
    
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

        // Y�����ɏ������㏸
        worldTarget += Vector3.up * floatUpSpeed * Time.deltaTime;

        // ���[���h���W����UI���W�ɕϊ�
        Vector3 screenPos = cam.WorldToScreenPoint(worldTarget);
        uiTransform.position = screenPos;

        // ���Ԍo�߂Ŕ�\��
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
