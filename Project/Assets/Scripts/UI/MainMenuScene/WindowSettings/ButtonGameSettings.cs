using UnityEngine;

using UIBaseClasses;

namespace UISettings
{
    public class ButtonGameSettings : BaseButton
    {
        [SerializeField] private WindowSettingsController windowSettingsController;

        protected override void DoThisOnClick()
        {
            windowSettingsController.ShowGameSetting();
        }
    }
}
