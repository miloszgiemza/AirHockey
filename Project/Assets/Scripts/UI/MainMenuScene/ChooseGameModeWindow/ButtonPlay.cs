using UnityEngine;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class ButtonPlay : BaseButton
    {
        private InputFieldScoreToWin inputFieldScoreToWin;

        protected override void Awake()
        {
            base.Awake();
            inputFieldScoreToWin = FindFirstObjectByType<InputFieldScoreToWin>();
        }

        protected override void DoThisOnClick()
        {
            GameController.Instance.StartGameplay(inputFieldScoreToWin.ReturnScoreToWin());
        }
    }
}

