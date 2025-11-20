using UnityEngine;

using UIBaseClasses;

namespace UIGameplayScene
{
    public class ButtonReturnToMainMenu : BaseButton
    {
        protected override void DoThisOnClick()
        {
            GameController.Instance.LoadMainMenuScene();
        }
    }
}

