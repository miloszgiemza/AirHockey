using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonQuitGame : BaseButton
    {
        protected override void DoThisOnClick()
        {
            GameController.Instance.QuitGame();
        }
    }
}
