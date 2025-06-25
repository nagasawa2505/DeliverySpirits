using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 50; // 1ステージの大きさ
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

        // 指定された数のステージを予め生成
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        int positionIndex = (int)(player.position.z / StageChipSize);
        if (positionIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(positionIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        // 生成済みのインデックスなら終了
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

    // ランダムでステージを生成
    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = Instantiate(stageChips[nextStageChip], new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);

        return stageObject;
    }

    // 一番古いステージを削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];

        generatedStageList.RemoveAt(0);

        Destroy(oldStage);
    }
}


