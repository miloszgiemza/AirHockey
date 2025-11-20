using UnityEngine;

namespace Players
{
    public class PlayerComputer2 : BasePlayerComputer
    {
        protected override Vector3 DefaultStrikerPosition => new Vector3(-0.13f, 0.68f, 5.13f);

        public PlayerComputer2(PlayerSide playerSide) : base(playerSide) { }

        protected override bool CheckIfPuckOutsideOfYourField(Puck puck)
        {
            return puck.transform.position.z < 0f;
        }

        protected override bool CheckIfPuckIsBehindYouAndYouStillHaveSpaceToMoveBack(Puck puck, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            return (puck.transform.position.z + spaceBehindPuckToStopMovingBack > striker.transform.position.z) && (striker.transform.position.z < playerMovementConstraints.ZAxisMax - striker.transform.localScale.z);
        }

        protected override bool CheckIfCanMoveBackToDefaultPosition(Vector3 defaultPosition, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            return striker.transform.position.z < defaultPosition.z - striker.transform.localScale.z;
        }

        protected override bool CheckIfPuckIsOnYourField(Puck puck)
        {
            return puck.transform.position.z > 0f;
        }

        protected override void RemoveOppositeMovementVectorsBeforeMovingForward(Striker striker)
        {
            if (striker.Rigidbody.linearVelocity.z > 0) striker.SetVelocity(new Vector3(striker.Rigidbody.linearVelocity.x, 0f, 0f));
        }

        protected override void RemoveOppositeMovementVectorsBeforeMovingBack(Striker striker)
        {
            if (striker.Rigidbody.linearVelocity.z < 0) striker.SetVelocity(new Vector3(striker.Rigidbody.linearVelocity.x, 0f, 0f));
        }

        protected override void MoveBackIfPuckIsBehindYou(Puck puck, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            RemoveOppositeMovementVectorsBeforeMovingBack(striker);
            MoveTowardsPosition(striker, striker.transform.position, new Vector3(striker.transform.position.x, striker.transform.position.y, playerMovementConstraints.ZAxisMax));
        }
    }
}

