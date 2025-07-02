using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TimeController timeCnt;
    public TextMeshProUGUI timeText;

    public GameObject gameOverPanel;

    int currentPoint; // UI���Ǘ����Ă���|�C���g
    public TextMeshProUGUI pointText;

    public Image boxImage;
    public Sprite[] boxPics;  // �\�����锠�̊G
    static int currentBoxNum;

    public string currentStageName;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI[] boxTexts;

    public GameObject resultPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeCnt = GetComponent<TimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState == GameState.playing)
        {
            // �c�莞�ԍX�V
            float rest = Mathf.Ceil(timeCnt.displayTime);
            timeText.text = rest.ToString();

            // �Q�[���I��
            if (rest <= 0)
            {
                GameController.gameState = GameState.timeover;

                // �ߋ��̃n�C�X�R�A���擾
                int highScore = PlayerPrefs.GetInt(currentStageName);

                // �n�C�X�R�A�X�V
                if (currentPoint > highScore)
                {
                    PlayerPrefs.SetInt(currentStageName, currentPoint);
                    highScore = currentPoint;
                }

                scoreText.text = "Score: " + currentPoint.ToString();
                highScoreText.text = "High Score: " + highScore.ToString();

                // �z�B�������\��
                for (int i = 0; i < boxTexts.Length; i++)
                {
                    float successRate = 0;
                    if (Shooter.shootCounts[i] != 0)
                    {
                        successRate = ((float)Post.successCounts[i] / Shooter.shootCounts[i]) * 100f;
                    }
                    boxTexts[i].text = "Box" + (i + 1) + " "
                        + Post.successCounts[i] + " / " + Shooter.shootCounts[i]
                        + " Success Rate: " + successRate.ToString("F1") + "%";
                }

                resultPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameController.gameState = GameState.end;
            }

            // �|�C���g�X�V
            if (currentPoint != GameController.stagePoints)
            {
                currentPoint = GameController.stagePoints;
                pointText.text = currentPoint.ToString();
            }

            // ���̊G�X�V
            if (currentBoxNum != Shooter.boxNum)
            {
                currentBoxNum = Shooter.boxNum;
                boxImage.sprite = boxPics[currentBoxNum];
            }
        }
        else if (GameController.gameState == GameState.gameover)
        {
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameController.gameState = GameState.end;
        }
    }
}
