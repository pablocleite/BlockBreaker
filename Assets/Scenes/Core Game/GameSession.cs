using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] int score = 0;

    private const string scoreTextMask = "SCORE: {0}";

    private void Awake()
    {
        //This is a very weird Singleton pattern code.
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void OnBlockDestroyed()
    {
        score += pointsPerBlock;
        UpdateScore();
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format(scoreTextMask, score.ToString());
    }
}
