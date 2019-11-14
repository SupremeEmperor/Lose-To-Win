﻿using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{


    public Sound[] sounds;
    public static AudioManager instance;
    
    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else if (SceneManager.GetActiveScene().name == "Victor Test" || (instance.gameObject.GetComponent<AudioSource>().clip != this.GetComponent<AudioSource>().clip)){
            Destroy(instance.gameObject);
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        Play("UnDungeon");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
