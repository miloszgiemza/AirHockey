using UnityEngine;

using GameEvents;

namespace GameplayControllerStateMachine
{
    public class StateScored : BaseState
    {
        public override StateID StateID => StateID.Scored;

        public override void InitializeState(GameplayController gameplayController)
        {
            CheckIfMatchWon(gameplayController);
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }

        private void CheckIfMatchWon(GameplayController gameplayController)
        {
            EventsGameplayUI.OnUpdatePlayer1Score.Invoke(gameplayController.Player1.Score);
            EventsGameplayUI.OnUpdatePlayer2Score.Invoke(gameplayController.Player2.Score);

            if(gameplayController.Player1.Score >= GameController.Instance.ScoreToWin || gameplayController.Player2.Score >= GameController.Instance.ScoreToWin)
            {
                gameplayController.SwitchState(StateID.Victory);
            }
            else
            {
                gameplayController.SwitchState(StateID.ResetPuck);
            }
        }
    }
}

