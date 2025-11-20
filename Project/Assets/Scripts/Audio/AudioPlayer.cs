using UnityEngine;

namespace Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance => instance;
        private static AudioPlayer instance;

        [SerializeField] private AudioSource sourceMusic;
        [SerializeField] private AudioSource sourceEffects;
        [SerializeField] private AudioSource sourceUI;

        private void Awake()
        {
            if(ReferenceEquals(AudioPlayer.Instance, null))
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void PlayMusic(AudioClip sound)
        {
            if(!ReferenceEquals(sound, null))
            {
                sourceMusic.clip = sound;
                sourceMusic.Play();
            }
        }

        public void PlayEffectSound(AudioClip sound)
        {
            if (!ReferenceEquals(sound, null))
            {
                sourceEffects.PlayOneShot(sound);
            }
        }

        public void PlayUISound(AudioClip sound)
        {
            if (!ReferenceEquals(sound, null)) sourceUI.PlayOneShot(sound);
        }
    }
}
