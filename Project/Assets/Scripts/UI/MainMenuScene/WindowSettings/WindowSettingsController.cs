using UnityEngine;

namespace UISettings
{
    public enum ActiveSettingsSection
    {
        GameSettings,
        AudioSettings
    }

    public class WindowSettingsController : MonoBehaviour
    {
        [SerializeField] private GameObject windowSettings;
        [SerializeField] private WindowSettingsSettingsSectionsSwitchButtonsHighlighter windowSettingsSettingsSectionsSwitchButtonsHighlighter;

        [SerializeField] private GameObject gameSettingsOptions;
        [SerializeField] private GameObject audioSettingsOptions;

        public void ShowWindowSettings()
        {
            windowSettings.SetActive(true);
            ShowGameSetting();
        }

        public void HideWindowSettings()
        {
            windowSettings.SetActive(false);
        }

        public void ShowGameSetting()
        {
            audioSettingsOptions.SetActive(false);
            gameSettingsOptions.SetActive(true);
            windowSettingsSettingsSectionsSwitchButtonsHighlighter.MarkGameSectionButtonAsActiveOrNot(ActiveSettingsSection.GameSettings);
        }

        public void ShowAudioSettings()
        {
            gameSettingsOptions.SetActive(false);
            audioSettingsOptions.SetActive(true);
            windowSettingsSettingsSectionsSwitchButtonsHighlighter.MarkGameSectionButtonAsActiveOrNot(ActiveSettingsSection.AudioSettings);
        }
    }
}

