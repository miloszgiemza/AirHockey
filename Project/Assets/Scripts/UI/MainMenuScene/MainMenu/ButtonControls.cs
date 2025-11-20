using UnityEngine;

using UIBaseClasses;
using UIWindowControls;

namespace UIMainMenuScene
{
    public class ButtonControls : BaseButton
    {
        [SerializeField] private MainMenuSceneUIController mainMenuSceneUIController;

        protected override void DoThisOnClick()
        {
            mainMenuSceneUIController.ShowControlsWindow();
        }
    }
}
