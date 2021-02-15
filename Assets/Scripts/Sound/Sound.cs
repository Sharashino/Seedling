using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip clip;

    public SoundType soundType;
    [Range(0f, 1f)]
    public float volume;
    public string name;
    public bool loop;
}

public enum SoundType
{
    Background,
    Click,
    PlantSeedling,
    HarvestSeedling,
    DoneGrowing,
    HarvestReady
}

