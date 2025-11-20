using UnityEngine;

using UIBaseClasses;

namespace UISettings
{
    public class ButtonAudioSettings : BaseButton
    {
        [SerializeField] private WindowSettingsController windowSettingsController;
        protected override void DoThisOnClick()
        {
            windowSettingsController.ShowAudioSettings();
        }
    }
}

