using UnityEngine;

namespace GameplayControllerStateMachine
{
    public class StatePlaying : BaseState
    {
        public override StateID StateID => StateID.Playing;

        public override void InitializeState(GameplayController gameplayController)
        {
            Time.timeScale = 1f;

            gameplayController.Player1.ConstraintPlayerMaxVelocity(gameplayController.Player1.MaxLinearVelocity, gameplayController.Striker1);
            gameplayController.Player2.ConstraintPlayerMaxVelocity(gameplayController.Player2.MaxLinearVelocity, gameplayController.Striker2);
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
            gameplayController.Puck.RunPuck();

            gameplayController.Player1.RunUpdate(gameplayController, gameplayController.Striker1, gameplayController.Table.Player1MovementConstraints);
            gameplayController.Player2.RunUpdate(gameplayController, gameplayController.Striker2, gameplayController.Table.Player2MovementConstraints);

            if(gameplayController.Table.GoalPlayer1.RunGoal())
            {
                gameplayController.Player2.IncreaseScore();
                gameplayController.Table.GoalPlayer1.ResetGoal();
                gameplayController.SwitchState(StateID.Scored);
            }
            if(gameplayController.Table.GoalPlayer2.RunGoal())
            {
                gameplayController.Player1.IncreaseScore();
                gameplayController.Table.GoalPlayer2.ResetGoal();
                gameplayController.SwitchState(StateID.Scored);
            }

            if(gameplayController.PuckUnblockIfBlocked.Blocked)
            {
                gameplayController.PuckUnblockIfBlocked.Reset();
                gameplayController.SwitchState(StateID.ResetPuck);
            }
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
            gameplayController.Player1.RunFixedUpdate(gameplayController, gameplayController.Striker1, gameplayController.Table.Player1MovementConstraints);
            gameplayController.Player2.RunFixedUpdate(gameplayController, gameplayController.Striker2, gameplayController.Table.Player2MovementConstraints);
        }
    }
}

