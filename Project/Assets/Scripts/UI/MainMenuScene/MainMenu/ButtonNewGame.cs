using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonNewGame : BaseButton
    {
        [SerializeField] private MainMenuSceneUIController mainMenuSceneUIController;

        protected override void DoThisOnClick()
        {
            mainMenuSceneUIController.ShowChooseGameModeWindow();
        }
    }
}
