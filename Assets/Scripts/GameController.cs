using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    timeover,
    playing,
    gameover,
    end
}

public class GameController : MonoBehaviour
{
    public static GameState gameState;
    public static int stagePoints;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.playing;
        stagePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
