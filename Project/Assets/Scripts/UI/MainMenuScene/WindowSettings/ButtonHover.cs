using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UIBaseClasses;
using GameSettingsAndSaveSystem;

namespace UISettings
{
    public class ButtonHover : BaseButton
    {
        private Color colorActive = new Color32(0, 46, 245, 255);
        private Color colorInactive = new Color32(0, 46, 245, 47);

        ColorBlock colorsButtonActiveMode;
        ColorBlock colorButtonInactiveMode;

        protected override void OnEnable()
        {
            base.OnEnable();

            colorsButtonActiveMode = button.colors;
            colorsButtonActiveMode.normalColor = colorActive;
            colorsButtonActiveMode.highlightedColor = colorActive;

            colorButtonInactiveMode = button.colors;
            colorButtonInactiveMode.normalColor = colorInactive;
            colorButtonInactiveMode.highlightedColor = colorActive;

            SwitchHighlightScheme(GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.HoverActive, true));
        }

        protected override void DoThisOnClick()
        {
            if(!GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.HoverActive, true))
            {
                GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.HoverActive, true);
                SwitchHighlightScheme(true);
            }
            else
            {
                GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.HoverActive, false);
                SwitchHighlightScheme(false);
                EventSystem.current.SetSelectedGameObject(null);
            }
        }

        private void SwitchHighlightScheme(bool active)
        {
            if (active) button.colors = colorsButtonActiveMode;
            else button.colors = colorButtonInactiveMode;
        }
    }
}

