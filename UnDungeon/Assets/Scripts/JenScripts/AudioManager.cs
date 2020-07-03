using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(instance.gameObject);
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
    
    public void Start()
    {
        Play("Title");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.source.clip.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        else
        {
            DisableOtherSounds(name);
            s.source.Play();
        }
    }
    
    public void ChangeSound(string name)
    {
        Play(name);
    }
    
    private void DisableOtherSounds(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.source.clip.name != name) s.source.Stop();
        }
    }
}
