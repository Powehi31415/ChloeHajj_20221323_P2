using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private float Timer = 0f;
    private float WaitTime = 0.35f;
    private float visualTime = 0f;
    public bool PlayButtonPressed;
    public bool ReturnButtonPressed;
    Audiomanager AudioManager;

    public void ButtonSound()
    {
        AudioManager.PlaySFX(AudioManager.Button);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        GameManager.instance.GoToMenu();
    }

    public void StartGame()
    {
        PlayButtonPressed = true;
    }

    public void ReturnHome()
    {
       ReturnButtonPressed = true;
    }

    private void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Audiomanager>();
        AudioManager.PlayBackground(AudioManager.Background);
        PlayButtonPressed = false;
        ReturnButtonPressed = false;
    }

    private void Update()
    {
        if (PlayButtonPressed == true)
        {
           Timer += Time.deltaTime;

            if (Timer > WaitTime)
            {
                visualTime = Timer;
                Timer = Timer - WaitTime;
                GoToGame();
            }
        }

        if (ReturnButtonPressed == true)
        {
            Timer += Time.deltaTime;

            if (Timer > WaitTime)
            {
                visualTime = Timer;
                Timer = Timer - WaitTime;
                GoToMenu();
            }
        }
    }
}
