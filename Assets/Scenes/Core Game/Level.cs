using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private int breakableBlocks;

    private SceneLoader sceneLoader;
    private GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }


    public void BlockAdded()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        gameStatus.OnBlockDestroyed();
        breakableBlocks--;
        if(breakableBlocks == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
