using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    private int breakableBlocks;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void BlockAdded()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
