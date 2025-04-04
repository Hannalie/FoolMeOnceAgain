using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
       //     DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Title");
    }
    public void PlayMusic(string name)
    {
        AudioClip audioClip = Array.Find(musicSounds, x => x.name == name);

        if (audioClip == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = audioClip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        AudioClip audioClip = Array.Find(sfxSounds, x => x.name == name);
        if (audioClip == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(audioClip);
            sfxSource.Play();
        }
    }

    public void StopMusic(string name)
    {
        Invoke("InvokeMusic", 1f);
    }

    public void StopSFX(string name)
    {
        sfxSource.Stop();
    }

    private void InvokeMusic()
    {
        musicSource.Stop();
    }
}
