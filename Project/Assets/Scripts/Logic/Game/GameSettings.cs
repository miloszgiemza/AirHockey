using UnityEngine;

using AudioClasses;

namespace GameSettingsAndSaveSystem
{
    public class GameSettings : MonoBehaviour
    {
        public enum SettingsOptions
        {
            ComputerDifficulty,
            PuckMaxSpeed,
            ActiveControlScheme,
            HoverActive,
            ControlsSensitivityPlayer1,
            ControlsSensitivityPlayer2,
            VolumeMaster,
            VolumeMusic,
            VolumeEffects,
            VolumeUI,
            TutorialPlayed
        }

        public static GameSettings Instance => instance;

        private static GameSettings instance;

        private void Awake()
        {
            if (ReferenceEquals(GameSettings.Instance, null))
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
                if (PlayerPrefs.HasKey(SettingsOptions.VolumeMaster.ToString())) AudioController.Instance.AudioMixer.SetFloat(AudioMixerExposedParams.MasterVolume.ToString(),
                PlayerPrefs.GetFloat(SettingsOptions.VolumeMaster.ToString()));
            if (PlayerPrefs.HasKey(SettingsOptions.VolumeMusic.ToString())) AudioController.Instance.AudioMixer.SetFloat(AudioMixerExposedParams.MusicVolume.ToString(),
                 PlayerPrefs.GetFloat(SettingsOptions.VolumeMusic.ToString()));
            if (PlayerPrefs.HasKey(SettingsOptions.VolumeEffects.ToString())) AudioController.Instance.AudioMixer.SetFloat(AudioMixerExposedParams.EffectsVolume.ToString(),
                 PlayerPrefs.GetFloat(SettingsOptions.VolumeEffects.ToString()));
            if (PlayerPrefs.HasKey(SettingsOptions.VolumeUI.ToString())) AudioController.Instance.AudioMixer.SetFloat(AudioMixerExposedParams.UIVolume.ToString(),
                 PlayerPrefs.GetFloat(SettingsOptions.VolumeUI.ToString()));
        }

        public void SetSetting(SettingsOptions settingKey, float settingValue)
        {
            PlayerPrefs.SetFloat(settingKey.ToString(), settingValue);
            PlayerPrefs.Save();
        }

        public void SetSetting(SettingsOptions settingKey, bool settingValue)
        {
            PlayerPrefs.SetInt(settingKey.ToString(), settingValue ? 1 : 0);
            PlayerPrefs.Save();
        }

        public void SetSetting(SettingsOptions settingKey, ControlsType controlsType)
        {
            PlayerPrefs.SetInt(settingKey.ToString(), (int) controlsType);
            PlayerPrefs.Save();
        }

        public float TryLoadSetting(SettingsOptions settingKey, float defaultValue)
        {
            float value = defaultValue;

            if(PlayerPrefs.HasKey(settingKey.ToString()))
            {
                value = PlayerPrefs.GetFloat(settingKey.ToString());
            }

            return value;
       }

        public bool TryLoadSetting(SettingsOptions settingKey, bool defaultValue)
        {
            bool value = defaultValue;

            if (PlayerPrefs.HasKey(settingKey.ToString()))
            {
                value = ( PlayerPrefs.GetInt(settingKey.ToString()) > 0 ) ? true : false ;
            }

            return value;
        }

        public ControlsType TryLoadSetting(SettingsOptions settingKey, ControlsType defaultValue)
        {
            ControlsType value = defaultValue;

            if (PlayerPrefs.HasKey(settingKey.ToString()))
            {
                value = (ControlsType) PlayerPrefs.GetInt(settingKey.ToString());
            }

            return value;
        }
    }
}
