using UnityEngine;

using GameHardwareAndInputClasses;
using GameSettingsAndSaveSystem;

namespace Players
{
    public class PlayerHuman : BasePlayer
    {
        public override float MaxLinearVelocity => 20f;

        private float maxStrikerLinearVelocitySwipe = 14.5f;

        private float minForcePerformSnapMovement = 0.12f;
        private float minDistanceToPerformMovement = 0.12f;

        private float maxDistanceToPerfromSnapMovementNoTeleportation = 2f;

        private float hoverModifiert = 0.2f;

        public PlayerHuman(PlayerSide playerSide, Striker striker) : base(playerSide) 
        {
            switch (playerSide)
            {
                case PlayerSide.Player1:

                    if (!GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.HoverActive, true)) hoverModifiert = -0.55f;
                    else hoverModifiert = 0.15f;

                    striker.SetMovementSpeedModifier(GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ControlsSensitivityPlayer1, striker.MovementSpeedModifier));
                    break;

                case PlayerSide.Player2:
                    striker.SetMovementSpeedModifier(GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ControlsSensitivityPlayer2, striker.MovementSpeedModifier));

                    if (GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.HoverActive, true)) hoverModifiert = -2;
                    else hoverModifiert = -1;
                    
                    break;
            }
        }

        public override void RunUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            PerformMovement(gameplayController, striker, playerMovementConstraints);
            ConstraintMovement(striker, playerMovementConstraints);
        }

        public override void ConstraintPlayerMaxVelocity(float maxOverallSpeed, Striker striker) 
        {
            switch(GameController.Instance.ControlsType)
            {
                case ControlsType.Swipe:
                    striker.ConstraintPlayerMaxVelocity(maxStrikerLinearVelocitySwipe);
                    break;
            }
        }

        protected override void PerformMovement(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            switch(playerSide)
            {
                case PlayerSide.Player1:

                    if (InputController.Instance.PrimaryTouchPressed && 
                        PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer1SideOfScreen(InputController.Instance.PrimaryTouchPosition))
                    {
                        switch(GameController.Instance.ControlsType)
                        {
                            case ControlsType.Snap:
                                MoveSnap(gameplayController, striker, CastScreenPositionToGameWorldPosition.Cast(InputController.Instance.PrimaryTouchPosition, Camera.main), playerMovementConstraints,
                                    InputController.Instance.PrimaryTouchSwipeValue);
                                break;

                            case ControlsType.Swipe:
                                MoveSwipe(gameplayController, striker, InputController.Instance.PrimaryTouchSwipeValue, playerMovementConstraints);
                                break;
                        }
                    }
                    else if (InputController.Instance.SecondaryTouchPressed &&
                        PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer1SideOfScreen(InputController.Instance.SecondaryTouchPosition))
                    {
                        switch(GameController.Instance.ControlsType)
                        {
                            case ControlsType.Snap:
                                MoveSnap(gameplayController, striker, CastScreenPositionToGameWorldPosition.Cast(InputController.Instance.SecondaryTouchPosition, Camera.main), playerMovementConstraints, 
                                    InputController.Instance.SecondaryTouchSwipeValue);
                                break;

                            case ControlsType.Swipe:
                                MoveSwipe(gameplayController, striker, InputController.Instance.SecondaryTouchSwipeValue, playerMovementConstraints);
                                break;
                        }
                    }
                    else
                    {
                        striker.StopStriker();
                    }

                    break;

                case PlayerSide.Player2:
                    
                    if (InputController.Instance.PrimaryTouchPressed &&
                        PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer2SideOfScreen(InputController.Instance.PrimaryTouchPosition))
                    {
                        switch(GameController.Instance.ControlsType)
                        {
                            case ControlsType.Snap:
                                MoveSnap(gameplayController, striker, CastScreenPositionToGameWorldPosition.Cast(InputController.Instance.PrimaryTouchPosition, Camera.main), playerMovementConstraints,
                                    InputController.Instance.PrimaryTouchSwipeValue);
                                break;

                            case ControlsType.Swipe:
                                MoveSwipe(gameplayController, striker, InputController.Instance.PrimaryTouchSwipeValue, playerMovementConstraints);
                                break;
                        }
                    }
                    else if (InputController.Instance.SecondaryTouchPressed &&
                        PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer2SideOfScreen(InputController.Instance.SecondaryTouchPosition))
                    {
                        switch(GameController.Instance.ControlsType)
                        {
                            case ControlsType.Snap:
                                MoveSnap(gameplayController, striker, CastScreenPositionToGameWorldPosition.Cast(InputController.Instance.SecondaryTouchPosition, Camera.main), playerMovementConstraints,
                                    InputController.Instance.SecondaryTouchSwipeValue);
                                break;

                            case ControlsType.Swipe:
                                MoveSwipe(gameplayController, striker, InputController.Instance.SecondaryTouchSwipeValue, playerMovementConstraints);
                                break;
                        }
                    }
                    else
                    {
                        striker.StopStriker();
                    }

                    break;
            }
        }

        bool firstFrame = false;

        private void MoveSnap(GameplayController gameplayController, Striker striker, Vector3 castedGameWorldCursorPosition, PlayerMovementConstraints playerMovementConstraints, Vector2 swipeValue)
        {
            Vector3 positionHoveringOverFinger = new Vector3(castedGameWorldCursorPosition.x, striker.transform.position.y,
                castedGameWorldCursorPosition.z + (striker.transform.localScale.z + hoverModifiert));

            if( Vector3.Distance(positionHoveringOverFinger, striker.transform.position) <= maxDistanceToPerfromSnapMovementNoTeleportation)
            {
                if (CheckForSnapMovementIfInputInsideTableBorders(positionHoveringOverFinger, playerMovementConstraints))
                {
                    if ((Vector3.Distance(positionHoveringOverFinger, striker.transform.position) >= minDistanceToPerformMovement)
                        && Mathf.Abs((positionHoveringOverFinger - striker.transform.position).magnitude) > minForcePerformSnapMovement)
                    {
                        striker.PerformSnapMovementPlayerHuman((positionHoveringOverFinger - striker.transform.position));
                    }
                    else striker.StopStriker();
                }
                else striker.StopStriker();
            }
  

            ConstraintForce(striker, playerMovementConstraints);
        }

        private void MoveSwipe(GameplayController gameplayController, Striker striker, Vector2 movementVector, PlayerMovementConstraints playerMovementConstraints)
        {
            striker.PerformSwipeMovementPlayerHuman(movementVector);
            ConstraintForceSwipe(striker, playerMovementConstraints);
            ConstraintMovement(striker, playerMovementConstraints);
            if (movementVector.x == 0 && movementVector.y == 0) striker.StopStriker();
        }

        private bool CheckForSnapMovementIfInputInsideTableBorders(Vector3 inputCastedToGameWorldPosition, PlayerMovementConstraints playerMovementConstraints)
        {
            bool insideTable = true;

            if (inputCastedToGameWorldPosition.x <= playerMovementConstraints.XAxisMin)
            {
                insideTable = false;
            }
            if (inputCastedToGameWorldPosition.x >= playerMovementConstraints.XAxisMax)
            {
                insideTable = false;
            }
            if (inputCastedToGameWorldPosition.z <= playerMovementConstraints.ZAxisMin)
            {
                insideTable = false;
            }
            if (inputCastedToGameWorldPosition.z >= playerMovementConstraints.ZAxisMax)
            {
                insideTable = false;
            }

            return insideTable;
        }
    }
}

