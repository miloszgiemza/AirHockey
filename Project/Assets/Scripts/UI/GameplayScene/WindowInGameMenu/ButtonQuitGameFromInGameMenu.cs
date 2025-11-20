using UnityEngine;

using UIBaseClasses;

namespace UIGameplayScene
{
    public class ButtonQuitGameFromInGameMenu : BaseButton
    {
        protected override void DoThisOnClick()
        {
            GameController.Instance.QuitGame();
        }
    }
}

