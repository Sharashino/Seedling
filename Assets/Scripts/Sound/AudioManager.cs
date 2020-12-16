using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
        }
    }

    public void PlaySound(string audioName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Play();
    }
}
