using UnityEngine;

using UIBaseClasses;
using UIMainMenuScene;

namespace UISettings
{
    public class ButtonBack : BaseButton
    {
        [SerializeField] private MainMenuSceneUIController mainMenuSceneUIController;

        protected override void DoThisOnClick()
        {
            mainMenuSceneUIController.ShowMainMenuWindowAndHideOthers();
        }
    }
}

