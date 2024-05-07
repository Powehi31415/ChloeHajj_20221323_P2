using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;

    [SerializeField]
    AudioSource MusicSource;
    [SerializeField]
    AudioSource SFXSource;

    public AudioClip Background;
    public AudioClip GameMusic;
    public AudioClip Jump;
    public AudioClip ColorChanger;
    public AudioClip Star;
    public AudioClip Button;
    public AudioClip Death;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBackground(AudioClip background)
    {
        MusicSource.clip = background;
        MusicSource.Play(); 
    }

    public void PlayGameMusic(AudioClip gameMusic)
    {
        MusicSource.clip = gameMusic;
        MusicSource.Play();
    }


    public void PlaySFX(AudioClip jump)
    {
        SFXSource.PlayOneShot(jump);
    }
}
