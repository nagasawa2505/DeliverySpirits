using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerGenerator : MonoBehaviour
{
    public GameObject dangerPrefab;
    public bool isRandom;
    public float intervalTime = 10.0f;
    public float minIntervalTime = 10.0f;
    public float maxIntervalTime = 20.0f;

    float timer;
    float posX;

    public GameObject dangerPanel;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState != GameState.playing)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DangerCreated();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer = isRandom ? Random.Range(minIntervalTime, (int)maxIntervalTime + 1) : intervalTime;
    }

    void DangerCreated()
    {
        int rand = Random.Range(PlayerController.MinLane, PlayerController.MaxLane + 1);
        posX = rand * PlayerController.LaneWidth;

        Instantiate(dangerPrefab, new Vector3(posX, 1, transform.position.z), dangerPrefab.transform.rotation);

        // �R���[�`���̔���
        StartCoroutine(AlertText());
    }

    IEnumerator AlertText()
    {
        float duration = 3.0f; // �_�Ŏ�������
        float blinkInterval = 0.05f; // �_�ŊԊu
        float blinkTimer = 0f; // �_�Ŏ��Ԃ̃J�E���g�_�E��

        while (blinkTimer < duration)
        {
            dangerPanel.SetActive(!dangerPanel.activeSelf);
            yield return new WaitForSeconds(0.05f);
            blinkTimer += blinkInterval;
        }
        dangerPanel.SetActive(false);
    }
}
