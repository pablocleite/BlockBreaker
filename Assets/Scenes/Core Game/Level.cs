using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private int breakableBlocks;

    private SceneLoader sceneLoader;
    private GameSession gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameSession>();
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
