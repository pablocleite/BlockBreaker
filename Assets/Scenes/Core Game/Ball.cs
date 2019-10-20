using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] soundFX;
    [SerializeField] float movementRandomFactor = 0.5f;

    private AudioSource audioSource;
    private Rigidbody2D rigidBody2D;
    private GameSession gameSession;

    Vector2 paddleToBallBehavior;
    bool launched;

    // Use this for initialization
    void Start()
    {
        launched = false;
        paddleToBallBehavior = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();
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
        if (gameSession.IsAutoPlayEnabled())
        {
            //Not following the paddle with Auto PlayEnable will fix some precision errors that causes drag on startup.
            return;
        }

        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallBehavior;
    }

    private void LaunchBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, movementRandomFactor),
                                        Random.Range(0f, movementRandomFactor));

        if (launched)
        {
            AudioClip clip = soundFX[Random.Range(0, soundFX.Length)];
            audioSource.PlayOneShot(clip);

            rigidBody2D.velocity += velocityTweak;
        }
    }
}
