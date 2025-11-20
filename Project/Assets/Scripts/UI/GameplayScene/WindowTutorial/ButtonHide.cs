using UnityEngine;

using UIBaseClasses;
using UIGameplayScene;
using GameplayControllerStateMachine;

namespace UITutorial
{
    public class ButtonHide : BaseButton
    {
        [SerializeField] private UIControllerGameplay uIControllerGameplay;
        [SerializeField] private GameplayController gameplayController;

        protected override void DoThisOnClick()
        {
            gameplayController.SwitchState(StateID.Playing);
            uIControllerGameplay.HideTutorialWindow();
        }
    }
}

