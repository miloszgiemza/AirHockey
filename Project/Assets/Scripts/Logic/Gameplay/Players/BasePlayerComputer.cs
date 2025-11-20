using UnityEngine;

using GameSettingsAndSaveSystem;

namespace Players
{
    public abstract class BasePlayerComputer : BasePlayer
    {
        public override float MaxLinearVelocity => GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ComputerDifficulty, defaultComputerDifficulty);

        public static float DefaultComputerDifficulty => defaultComputerDifficulty;
        public static float MinComputerDifficulty => minComputerDifficulty;
        public static float MaxComputerDifficulty => maxComputerDifficulty;

        protected abstract Vector3 DefaultStrikerPosition { get; }

        protected float speedModifier = 100f;

        protected static float defaultComputerDifficulty = 7.5f;
        protected static float minComputerDifficulty = 5f;
        protected static float maxComputerDifficulty = 12f;

        protected float spaceBehindPuckToStopMovingBack = 0f;

        public BasePlayerComputer(PlayerSide playerSide) : base(playerSide) {}

        protected abstract bool CheckIfPuckOutsideOfYourField(Puck puck);
        protected abstract bool CheckIfPuckIsBehindYouAndYouStillHaveSpaceToMoveBack(Puck puck, Striker striker, PlayerMovementConstraints playerMovementConstraints);
        protected abstract bool CheckIfCanMoveBackToDefaultPosition(Vector3 defaultPosition, Striker striker, PlayerMovementConstraints playerMovementConstraints);
        protected abstract bool CheckIfPuckIsOnYourField(Puck puck);

        public override void RunUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints) {}
        public override void RunFixedUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            PerformMovement(gameplayController, striker, playerMovementConstraints);
        }

        public override void ConstraintPlayerMaxVelocity(float maxOverallSpeed, Striker striker)
        {
            striker.ConstraintPlayerMaxVelocity(maxOverallSpeed);
        }

        protected override void PerformMovement(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            if (CheckIfPuckOutsideOfYourField(gameplayController.Puck) && CheckIfCanMoveBackToDefaultPosition(DefaultStrikerPosition, striker, playerMovementConstraints))
            {
                MoveToDefaultPositionIfPuckIsOnTheOtherSideOfTable(gameplayController.Puck, striker, DefaultStrikerPosition);
            }
            else if (CheckIfPuckIsBehindYouAndYouStillHaveSpaceToMoveBack(gameplayController.Puck, striker, playerMovementConstraints))
            {
                MoveBackIfPuckIsBehindYou(gameplayController.Puck, striker, playerMovementConstraints);
            }
            else if(CheckIfPuckIsOnYourField(gameplayController.Puck))
            {
                StrikePuckIfInFrontOfYou(gameplayController.Puck, striker);
            }
        }

        protected abstract void RemoveOppositeMovementVectorsBeforeMovingForward(Striker striker);

        protected void StrikePuckIfInFrontOfYou(Puck puck, Striker striker)
        {
            RemoveOppositeMovementVectorsBeforeMovingForward(striker);
            MoveTowardsPosition(striker, striker.transform.position, puck.transform.position);
        }

        protected abstract void MoveBackIfPuckIsBehindYou(Puck puck, Striker striker, PlayerMovementConstraints playerMovementConstraints);

        protected abstract void RemoveOppositeMovementVectorsBeforeMovingBack(Striker striker);

        protected void MoveToDefaultPositionIfPuckIsOnTheOtherSideOfTable(Puck puck, Striker striker, Vector3 defaultStrikerPosition)
        {
            RemoveOppositeMovementVectorsBeforeMovingBack(striker);
            MoveTowardsPosition(striker, striker.transform.position, defaultStrikerPosition);
        }

        protected void MoveTowardsPosition(Striker striker, Vector3 startPosition, Vector3 targetPosition)
        {
            striker.PerformMovementPlayerComputer((targetPosition - startPosition).normalized * speedModifier, 
                GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ComputerDifficulty, defaultComputerDifficulty));
        }
    }
}

