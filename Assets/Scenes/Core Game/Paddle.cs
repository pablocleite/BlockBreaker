using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    private GameSession gameSession;
    private Ball ball;

    // Use this for initialization
    void Start () {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
	}

    private void UpdatePosition()
    {
        float positionInUnits = Mathf.Clamp(GetXPosition(), minX, maxX);
        Vector2 coordinates = new Vector2(positionInUnits, transform.position.y);
        transform.position = coordinates;
    }

    private float GetXPosition()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return GetBallXPosition(); 
        }
        else
        {
            return GetMouseXPosition();
        }
    }

    private float GetMouseXPosition()
    {
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }

    private float GetBallXPosition()
    {
        return ball.transform.position.x;
    }
}
