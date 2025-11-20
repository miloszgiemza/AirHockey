using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonGameModeTwoPlayers : BaseButton
    {
        [SerializeField] private ChooseGameModeWindow chooseGameModeWindow;

        protected override void DoThisOnClick()
        {
            GameController.Instance.SwitchGameMode(GameMode.TwoPlayers);
            chooseGameModeWindow.MarkGameModeButtonsAsActiveOrNot();
        }
    }
}
