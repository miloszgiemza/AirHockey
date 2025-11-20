using UnityEngine;

using UnityEngine.UI;

namespace UISettings
{
    public class WindowSettingsSettingsSectionsSwitchButtonsHighlighter : MonoBehaviour
    {
        [SerializeField] private Button buttonGameSettingsSection;
        [SerializeField] private Button buttonAudioSection;

        private Color colorActive = new Color32(0, 46, 245, 255);
        private Color colorInactive = new Color32(0, 46, 245, 47);

        public void MarkGameSectionButtonAsActiveOrNot(ActiveSettingsSection activeSettingsSection)
        {
            ColorBlock colorsButtonActiveMode = buttonGameSettingsSection.colors;
            colorsButtonActiveMode.normalColor = colorActive;
            colorsButtonActiveMode.highlightedColor = colorActive;

            ColorBlock colorsButtonInactiveMode = buttonAudioSection.colors;
            colorsButtonInactiveMode.normalColor = colorInactive;
            colorsButtonInactiveMode.highlightedColor = colorActive; ;

            switch (activeSettingsSection)
            {
                case ActiveSettingsSection.GameSettings:

                    buttonGameSettingsSection.colors = colorsButtonActiveMode;
                    buttonAudioSection.colors = colorsButtonInactiveMode;

                    break;

                case ActiveSettingsSection.AudioSettings:

                    buttonGameSettingsSection.colors = colorsButtonInactiveMode;
                    buttonAudioSection.colors = colorsButtonActiveMode;

                    break;
            }
        }
    }
}
