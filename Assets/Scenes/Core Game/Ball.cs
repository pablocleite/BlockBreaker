﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;

    Vector2 paddleToBallBehavior;
    bool launched;

    // Use this for initialization
    void Start()
    {
        launched = false;
        paddleToBallBehavior = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            FollowThePaddle();

            if (Input.GetMouseButtonDown(0))
            {
                LaunchBall();
                launched = true;
            }
        }
    }

    private void FollowThePaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallBehavior;
    }

    private void LaunchBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
    }
}