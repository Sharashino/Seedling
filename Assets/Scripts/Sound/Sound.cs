using UnityEngine;
using Seedling.Enums;

namespace Seedling.Sounds
{
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
}
