using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public ObstacleSpawner obstacleSpawner;
    public Sprite fishDied;
    SpriteRenderer _sp;
    Animator _anim;
    [SerializeField] private AudioSource swim, hit, point;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _sp = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false) {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 5f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else 
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0) {
            if (angle <= maxAngle)
                angle += 4;
        }
        else if (_rb.velocity.y < -2.5f) {
            if (angle > minAngle)
                angle -= 2;
        }
        
        if (touchedGround == false)
            transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column") && GameManager.gameOver == false) {
            gameManager.GameOver();
            GameOver();
            FishDieEffect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            if (GameManager.gameOver == false) {
                gameManager.GameOver();
                GameOver();
                FishDieEffect();
            }
    }

    void FishDieEffect() 
    {
        hit.Play();
    }

    void GameOver()
    {
        touchedGround = true;
        _anim.enabled = false;
        _sp.sprite = fishDied;
        transform.rotation = Quaternion.Euler(0,0,-90);
    }
}
