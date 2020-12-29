using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public Sound[] sounds;


    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }
    }

    private void Start()
    {
        if(gameManager.GetIsAllMuted())
        {
            return;
        }
        else
        {
            PlaySound("BackgroundSound");
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if(s == null)
        {
            Debug.Log("Wrong " +s+ " sound name in editor!");
            return;
        }

        s.audioSource.Play();
    }

    public void MuteAllSounds()
    {
        if(gameManager.GetIsAllMuted())
        {
            PlaySound("BackgroundSound");
            
            foreach (Sound sound in sounds)
            {
                sound.volume = 0;
            }

            gameManager.SetIsBackgroundMuted(false);
        }
        else
        {
            foreach (Sound sound in sounds)
            {
                sound.audioSource.Stop();
                sound.volume = 0;
            }
            
            gameManager.SetIsBackgroundMuted(true);
        }
    }
}