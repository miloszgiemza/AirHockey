using UnityEngine;

using Players;

namespace GameplayControllerStateMachine
{
    public class StateVictory : BaseState
    {
        public override StateID StateID => StateID.Victory;

        public override void InitializeState(GameplayController gameplayController)
        {
            PlayerSide winner;

            if(gameplayController.Player1.Score >= GameController.Instance.ScoreToWin)
            {
                winner = gameplayController.Player1.PlayerSide;
            }
            else
            {
                winner = gameplayController.Player2.PlayerSide;
            }

            gameplayController.UIControllerGameplay.ShowVictoryWindow(winner);
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }
    }
}

