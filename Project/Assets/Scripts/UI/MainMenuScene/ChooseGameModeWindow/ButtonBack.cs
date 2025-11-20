using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonBack : BaseButton
    {
        [SerializeField] private ChooseGameModeWindowController chooseGameModeWindowController;

        protected override void DoThisOnClick()
        {
            chooseGameModeWindowController.HideChooseGameModeWindow();
        }
    }
}
