using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    GameObject ObstaclesGenerator;

    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Audiomanager AudioManager;

    private float Timer = 0f;
    private float WaitTime = 0.627f;
    private float visualTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audiomanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.PlaySFX(AudioManager.Jump);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            GameManager.instance.SetRandomColor(gameObject);
            ObstaclesGenerator.GetComponent<ObstaclesGenerator>().RandomGenerator();
            AudioManager.PlaySFX(AudioManager.ColorChanger);
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.CompareTag("Star"))
            {
                GameManager.instance.SetScore();
                AudioManager.PlaySFX(AudioManager.Star);
                Destroy(collision.gameObject);
            }
            else
            {
                if (collision.gameObject.CompareTag(gameObject.tag) == false)
                {
                    AudioManager.PlaySFX(AudioManager.Death);
                    GameManager.instance.GameOver();
                }
            }
        }
    }
}
