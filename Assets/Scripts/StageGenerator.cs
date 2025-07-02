using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 50; // 1�X�e�[�W�̑傫��
    int currentChipIndex;
    Transform player;
    public GameObject[] stageChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentChipIndex = startChipIndex - 1; // 0

        // �w�肳�ꂽ���̃X�e�[�W��\�ߐ���
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        int positionIndex = (int)(player.position.z / StageChipSize);
        if (positionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(positionIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        // �����ς݂̃C���f�b�N�X�Ȃ�I��
        if (toChipIndex <= currentChipIndex)
        {
            return;
        }

        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            generatedStageList.Add(stageObject);
        }

        while (generatedStageList.Count > preInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentChipIndex = toChipIndex;
    }

    // �����_���ŃX�e�[�W�𐶐�
    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

    // stageChips[0] NULL!!!
        return Instantiate(stageChips[nextStageChip], new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);
    }

    // ��ԌÂ��X�e�[�W���폜
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];

        generatedStageList.RemoveAt(0);

        Destroy(oldStage);
    }
}


