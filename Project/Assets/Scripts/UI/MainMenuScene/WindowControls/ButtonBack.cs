using UnityEngine;

using UIBaseClasses;
using UIMainMenuScene;

namespace UIWindowControls
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

