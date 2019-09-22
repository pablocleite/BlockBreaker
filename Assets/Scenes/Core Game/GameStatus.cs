using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score = 0;

    private const string scoreTextMask = "SCORE: {0}";
    

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void OnBlockDestroyed()
    {
        score += pointsPerBlock;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format(scoreTextMask, score.ToString());
    }
}
