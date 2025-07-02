using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float startTime = 60.0f;
    public float displayTime; // UI�ƘA������c�莞��
    float pastTime; // �o�ߎ���
    bool isTimeOver;

    // Start is called before the first frame update
    void Start()
    {
        // �܂��͊���Ԃ��Z�b�g
        displayTime = startTime;
        pastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C���I�[�o�[�Ȃ牽�����Ȃ�
        if (isTimeOver)
        {
            return;
        }

        // �o�ߎ��Ԃ̎Z�o
        pastTime += Time.deltaTime;
        displayTime = startTime - pastTime;

        // �c�莞�Ԃ�0�̂Ƃ�
        if (displayTime <= 0)
        {
            displayTime = 0;
            isTimeOver = true;
        }
    }
}
