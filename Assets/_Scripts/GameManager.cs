using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentColor;
    public Color Cyan;
    public Color Pink;
    public Color Purple;
    public Color Yellow;

    public float Score;

    [SerializeField]
    GameObject Player;
    SpriteRenderer ObjectColor;
    Audiomanager AudioManager;

    private bool HomeButtonPressed;
    private float Timer = 0f;
    private float WaitTime = 0.35f;
    private float visualTime = 0f;

    bool isDead;
    float deathTimer;

    private void Awake()
    {
        instance = this;

        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audiomanager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        HomeButtonPressed = false;
        SetRandomColor(Player);
        AudioManager.PlayGameMusic(AudioManager.GameMusic);
        isDead = false;
        deathTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score >= PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", Score);
            PlayerPrefs.Save();
        }

        if (HomeButtonPressed == true)
        {
             GoToMenu();
        }

        if (isDead)
        {
            deathTimer += Time.deltaTime;

            if (deathTimer > 0.628f)
            {
                SceneManager.LoadScene("RetryMenu");
            }
        }
    }

    public void SetRandomColor(GameObject obj)
    {
        int index = Random.Range(0, 4);

        ObjectColor = obj.GetComponent<SpriteRenderer>();

        switch (index) {
            case 0:
                currentColor = "Pink";
                ObjectColor.color = Pink;
                obj.tag = "Pink";
                break;
            case 1:
                currentColor = "Cyan";
                ObjectColor.color = Cyan;
                obj.tag = "Cyan";
                break;
            case 2:
                currentColor = "Purple";
                ObjectColor.color = Purple;
                obj.tag = "Purple";
                break;
            case 3:
                currentColor = "Yellow";
                ObjectColor.color = Yellow;
                obj.tag = "Yellow";
                break;
        }
    }

    public void SetScore()
    {
        Score = Score + 1;
    }
    public float GetScore()
    {
        return Score;
    }

    public float GetHighscore()
    {
        return PlayerPrefs.GetFloat("Highscore");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        isDead = true;
        Destroy(Player);
    }

    public void ButtonSound()
    {
        AudioManager.PlaySFX(AudioManager.Button);
    }

    public void ReturnToMenu()
    {
        HomeButtonPressed = true;
    }
}
