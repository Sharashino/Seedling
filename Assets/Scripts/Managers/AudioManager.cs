using System;
using UnityEngine;

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
        if(gameManager.IsBackgroundMuted)
        {
            return;
        }
        else
        {
            PlaySound(SoundType.Background);
        }
    }

    public void PlaySound(SoundType soundType)
    {
        Sound s = Array.Find(sounds, sound => sound.soundType == soundType);

        if(s == null)
        {
            Debug.Log("Wrong " +s+ " sound type in editor!");
            return;
        }

        s.audioSource.Play();
    }

    public void MuteAllSounds()
    {
        if(gameManager.IsBackgroundMuted)
        {
            PlaySound(SoundType.Background);

            foreach (Sound sound in sounds)
            {
                sound.volume = 1;
            }

            gameManager.IsBackgroundMuted = false;
        }
        else
        {
            foreach (Sound sound in sounds)
            {
                sound.audioSource.Stop();
                sound.volume = 0;
            }
            
            gameManager.IsBackgroundMuted = false;
        }
    }
}