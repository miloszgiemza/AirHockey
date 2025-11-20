using UnityEngine;
using UnityEngine.Audio;

namespace AudioClasses
{
    public enum AudioMixerExposedParams
    {
        MasterVolume,
        MusicVolume,
        EffectsVolume,
        UIVolume
    }

    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance => instance;

        public AudioMixer AudioMixer => audioMixer;

        private static AudioController instance;

        [SerializeField] private AudioMixer audioMixer;

        private float minLinearVolumeValue = 0.0001f;
        private float maxLinearVolumeValue = 1f;

        private void Awake()
        {
            if(ReferenceEquals(AudioController.Instance, null))
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public float ConvertLinearVolumeToLogarithmic(float linearValue)
        {
            Mathf.Clamp(linearValue, minLinearVolumeValue, maxLinearVolumeValue);
            float logarythmicValue = -80f;
            if (linearValue > 0.0001f) logarythmicValue = Mathf.Log10(linearValue) * 20;
            return logarythmicValue;
        }

        public float ConvertLogarithmicValueToLinear(float logarythmicValue)
        {
            return Mathf.Pow(10, logarythmicValue / 20f);
        }

        public void SetMasterVolume(float linearVolumeValue)
        {
            audioMixer.SetFloat(AudioMixerExposedParams.MasterVolume.ToString(), ConvertLinearVolumeToLogarithmic(linearVolumeValue));
;        }

        public void SetMusicVolume(float linearVolumeValue)
        {
            audioMixer.SetFloat(AudioMixerExposedParams.MusicVolume.ToString(), ConvertLinearVolumeToLogarithmic(linearVolumeValue));
        }

        public void SetEffectsVolume(float linearVolumeValue)
        {
            audioMixer.SetFloat(AudioMixerExposedParams.EffectsVolume.ToString(), ConvertLinearVolumeToLogarithmic(linearVolumeValue));
        }

        public void SetUIVolume(float linearVolumeValue)
        {
            audioMixer.SetFloat(AudioMixerExposedParams.UIVolume.ToString(), ConvertLinearVolumeToLogarithmic(linearVolumeValue));
        }
    }
}
