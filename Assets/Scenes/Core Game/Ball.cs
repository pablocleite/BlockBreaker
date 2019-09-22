using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] soundFX;

    private AudioSource audioSource;

    Vector2 paddleToBallBehavior;
    bool launched;

    // Use this for initialization
    void Start()
    {
        launched = false;
        paddleToBallBehavior = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launched)
        {
            AudioClip clip = soundFX[Random.Range(0, soundFX.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
