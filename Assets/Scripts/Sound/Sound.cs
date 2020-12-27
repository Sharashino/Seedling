using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public string name;
    public bool loop;
}
