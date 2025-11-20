using UnityEngine;

using UIBaseClasses;

namespace UIGameplayScene
{
    public class ButtonResumeGameplayFromInGameMenu : BaseButton
    {
        [SerializeField] private GameplayController gameplayController;
        [SerializeField] private UIControllerGameplay uIControllerGameplay;

        protected override void DoThisOnClick()
        {
            gameplayController.UnfreezeGameplay();
            uIControllerGameplay.HideInGameMenuWindow();
        }
    }
}

