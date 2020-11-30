using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
}
