using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour

{
    private static AudioManager instance = null;

    public Sound[] sounds;

    void Awake()
    {
        // uncomment this part if you want only one AudioManager in all scenes

        //if (instance == null)
        //    instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //DontDestroyOnLoad(gameObject);

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
