﻿using UnityEngine.Audio;
using System;
using UnityEngine;

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
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + " not found!");
            return;
        }
        s.source.Play();
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
    }

    void Start()
    {
        Play("Theme");
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Stop();
    }
}
//FindObjectOfType<AudioManager>().Play("name of the audio file"); - plays the audio file or Play("name of the audio file"); and for stopplaying (AudioManagerReferenceGoeshere).StopPlaying("sound string name"); or if (...){   FindObjectOfType<AudioManager>().StopPlaying("...");  FindObjectOfType<AudioManager>().Play("..."); }