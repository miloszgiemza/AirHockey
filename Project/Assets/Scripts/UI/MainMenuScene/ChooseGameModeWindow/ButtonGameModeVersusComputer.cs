using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonGameModeVersusComputer : BaseButton
    {
        [SerializeField] private ChooseGameModeWindow chooseGameModeWindow;

        protected override void DoThisOnClick()
        {
            GameController.Instance.SwitchGameMode(GameMode.Computer);
            chooseGameModeWindow.MarkGameModeButtonsAsActiveOrNot();
        }
    }
}

