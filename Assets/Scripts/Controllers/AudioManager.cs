using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 
  
    public Sound[] sounds;

    void Awake()
    {

            if (Instance == null)
            {
                Instance = this; // Set the instance
            }
            else
            {
                Destroy(gameObject); // Destroy duplicate objects, not just the script
                return;
            }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex ==1)
        Play("OST");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
}
