using UnityEngine;

using UIBaseClasses;
using AudioClasses;
using GameSettingsAndSaveSystem;

namespace UISettings
{
    public class VolumeSliderEffects : BaseSlider
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            float logValue;
            AudioController.Instance.AudioMixer.GetFloat(AudioMixerExposedParams.EffectsVolume.ToString(), out logValue);
            slider.value = AudioController.Instance.ConvertLogarithmicValueToLinear(logValue);
        }

        protected override void DoThisWhenPlayerSlidesSlider(float sliderNewValue)
        {
            AudioController.Instance.SetEffectsVolume(sliderNewValue);
            float newMixerValue;
            AudioController.Instance.AudioMixer.GetFloat(AudioMixerExposedParams.MasterVolume.ToString(), out newMixerValue);
            GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.VolumeEffects, newMixerValue);
        }
    }
}

