using UnityEngine;

using Players;

namespace MainMenuSimulatedBackground
{
    public class SimulatedBackgroundController : GameplayController
    {
        protected override void Awake()
        {
            puck = GetComponentInChildren<Puck>();
            table = GetComponentInChildren<Table>();

            CreatePlayers(new PlayerComputer1(PlayerSide.Player1), new PlayerComputer2(PlayerSide.Player2));
        }

        protected override void Start() 
        {
            Time.timeScale = 1f;

            player1.ConstraintPlayerMaxVelocity(player1.MaxLinearVelocity, striker1);
            player2.ConstraintPlayerMaxVelocity(player2.MaxLinearVelocity, striker2);
        }

        protected override void Update()
        {
            puck.RunPuck();

            player1.RunUpdate(this, striker1, table.Player1MovementConstraints);
            player2.RunUpdate(this, striker2, table.Player2MovementConstraints);

            if (table.GoalPlayer1.RunGoal())
            {
                table.GoalPlayer1.ResetGoal();
                puck.SetPuckPosition(table.DefaultPuckPosition);
            }
            if (table.GoalPlayer2.RunGoal())
            {
                table.GoalPlayer2.ResetGoal();
                puck.SetPuckPosition(table.DefaultPuckPosition);
            }
        }

        protected override void FixedUpdate()
        {
            player1.RunFixedUpdate(this, striker1, table.Player1MovementConstraints);
            player2.RunFixedUpdate(this, striker2, table.Player2MovementConstraints);
        }
    }
}

