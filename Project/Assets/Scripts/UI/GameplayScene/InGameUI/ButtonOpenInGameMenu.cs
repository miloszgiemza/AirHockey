using UnityEngine;

using UIBaseClasses;

namespace UIGameplayScene
{
    public class ButtonOpenInGameMenu : BaseButton
    {
        [SerializeField] private UIControllerGameplay uIControllerGameplay;
        [SerializeField] private GameplayController gameplayController;

        protected override void Awake()
        {
            uIControllerGameplay = FindFirstObjectByType<UIControllerGameplay>();
            gameplayController = FindFirstObjectByType<GameplayController>();
            base.Awake();
        }
        protected override void DoThisOnClick()
        {
            gameplayController.FreezeGameplay();
            uIControllerGameplay.ShowInGameMenuWindow();
        }
    }
}

