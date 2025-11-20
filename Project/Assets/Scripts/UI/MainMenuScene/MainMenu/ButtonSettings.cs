using UnityEngine;

using UIBaseClasses;
using UISettings;

namespace UIMainMenuScene
{
    public class ButtonSettings : BaseButton
    {
        [SerializeField] private MainMenuSceneUIController mainMenuSceneUIController;

        protected override void DoThisOnClick()
        {
            mainMenuSceneUIController.ShowSettingsWindow();
        }
    }
}

