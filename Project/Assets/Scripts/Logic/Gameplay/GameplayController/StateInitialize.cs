using UnityEngine;

using Players;

namespace GameplayControllerStateMachine
{
    public class StateInitialize : BaseState
    {
        public override StateID StateID => StateID.Initialize;

        public override void InitializeState(GameplayController gameplayController)
        {
            switch(GameController.Instance.GameMode)
            {
                case GameMode.TwoPlayers:
                    gameplayController.CreatePlayers(new PlayerHuman(PlayerSide.Player1, gameplayController.Striker1), new PlayerHuman(PlayerSide.Player2, gameplayController.Striker2));
                    break;

                case GameMode.Computer:
                    gameplayController.CreatePlayers(new PlayerHuman(PlayerSide.Player1, gameplayController.Striker1), new PlayerComputer2(PlayerSide.Player2));
                    break;
            }

            gameplayController.SwitchState(StateID.Intro);
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }
    }
}

