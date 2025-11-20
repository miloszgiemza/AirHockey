using UnityEngine;

using UIBaseClasses;

namespace UIGameplayScene
{
    public class ButtonWindowVictory : BaseButton
    {
        protected override void DoThisOnClick()
        {
            GameController.Instance.LoadMainMenuScene();
        }
    }
}
