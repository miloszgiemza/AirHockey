using System;
using UnityEngine;

namespace Players
{
    public enum PlayerSide
    {
        Player1,
        Player2
    }

    [Serializable]
    public struct PlayerMovementConstraints
    {
        public float XAxisMin => xAxisMin;
        public float XAxisMax => xAxisMax;
        public float ZAxisMin => zAxisMin;
        public float ZAxisMax => zAxisMax;

        [SerializeField] private float xAxisMin;
        [SerializeField] private float xAxisMax;
        [SerializeField] private float zAxisMin;
        [SerializeField] private float zAxisMax;

        public PlayerMovementConstraints(float xAxisMin, float xAxisMax, float zAxisMin, float zAxisMax)
        {
            this.xAxisMin = xAxisMin;
            this.xAxisMax = xAxisMax;
            this.zAxisMin = zAxisMin;
            this.zAxisMax = zAxisMax;
        }
    }

    public abstract class BasePlayer
    {
        public PlayerSide PlayerSide => playerSide;

        public int Score => score;

        public abstract float MaxLinearVelocity { get; }

        [SerializeField] protected Goal opponentGoal;
        [SerializeField] protected Striker ownedStriker;

        protected PlayerSide playerSide;

        protected int score = 0;

        protected float edgeOfMapMargin = 0.3f;

        public BasePlayer(PlayerSide playerSide)
        {
            this.playerSide = playerSide;
        }

        public abstract void RunUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints);
        public abstract void RunFixedUpdate(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints);
        public abstract void ConstraintPlayerMaxVelocity(float maxOverallSpeed, Striker striker); 

        public void IncreaseScore()
        {
            score++;
        }

        protected virtual void ConstraintForce(Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            if (striker.transform.position.x <= playerMovementConstraints.XAxisMin + (striker.transform.localScale.x / 2))
            {
                striker.SetVelocity( new Vector3( Mathf.Clamp( striker.Rigidbody.linearVelocity.x, 0, float.MaxValue), striker.Rigidbody.linearVelocity.y,
                    striker.Rigidbody.linearVelocity.z) );
            }
            if (striker.transform.position.x >= playerMovementConstraints.XAxisMax - (striker.transform.localScale.x / 2))
            {
                striker.SetVelocity( new Vector3( Mathf.Clamp(striker.Rigidbody.linearVelocity.x, float.MinValue, 0), striker.Rigidbody.linearVelocity.y, 
                    striker.Rigidbody.linearVelocity.z) );
            }
            if (striker.transform.position.z <= playerMovementConstraints.ZAxisMin + (striker.transform.localScale.z / 2))
            {
                striker.SetVelocity( new Vector3(striker.Rigidbody.linearVelocity.x, striker.Rigidbody.linearVelocity.y, 
                    Mathf.Clamp(striker.Rigidbody.linearVelocity.z, 0, float.MaxValue)) );
            }
            if (striker.transform.position.z >= playerMovementConstraints.ZAxisMax - (striker.transform.localScale.z / 2))
            {
                striker.SetVelocity( new Vector3( striker.Rigidbody.linearVelocity.x, striker.Rigidbody.linearVelocity.y, Mathf.Clamp( striker.Rigidbody.linearVelocity.z, float.MinValue, 0) ) );
            }
        }

        protected virtual void ConstraintForceSwipe(Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            if (striker.transform.position.x <= playerMovementConstraints.XAxisMin + (striker.transform.localScale.x / 2))
            {
                striker.StopStriker();
            }
            if (striker.transform.position.x >= playerMovementConstraints.XAxisMax - (striker.transform.localScale.x / 2))
            {
                striker.StopStriker();
            }
            if (striker.transform.position.z <= playerMovementConstraints.ZAxisMin + (striker.transform.localScale.z / 2))
            {
                striker.StopStriker();
            }
            if (striker.transform.position.z >= playerMovementConstraints.ZAxisMax - (striker.transform.localScale.z / 2))
            {
                striker.StopStriker();
            }
        }

        protected virtual void ConstraintMovement(Striker striker, PlayerMovementConstraints playerMovementConstraints)
        {
            if (striker.transform.position.x <= playerMovementConstraints.XAxisMin + (striker.transform.localScale.x / 2)) 
            {
                striker.transform.position = new Vector3(playerMovementConstraints.XAxisMin + (striker.transform.localScale.x / 2) + edgeOfMapMargin, 
                    striker.transform.position.y, striker.transform.position.z);

                striker.SetVelocity(new Vector3(0f, 0f, 0f));
            } 
            if (striker.transform.position.x >= playerMovementConstraints.XAxisMax - (striker.transform.localScale.x / 2))
            {
                striker.transform.position = new Vector3(playerMovementConstraints.XAxisMax - (striker.transform.localScale.x / 2) - edgeOfMapMargin,
                    striker.transform.position.y, striker.transform.position.z);

                striker.SetVelocity(new Vector3(0f, 0f, 0f));
            }
            if (striker.transform.position.z <= playerMovementConstraints.ZAxisMin + (striker.transform.localScale.z / 2))
            {
                striker.transform.position = new Vector3(striker.transform.position.x,
                 striker.transform.position.y, playerMovementConstraints.ZAxisMin + (striker.transform.localScale.z / 2) + edgeOfMapMargin);

                striker.SetVelocity(new Vector3(0f, 0f, 0f));
            }
            if (striker.transform.position.z >= playerMovementConstraints.ZAxisMax - (striker.transform.localScale.z / 2))
            {
                striker.transform.position = new Vector3(striker.transform.position.x,
                 striker.transform.position.y, playerMovementConstraints.ZAxisMax - (striker.transform.localScale.z / 2) - edgeOfMapMargin);

                striker.SetVelocity(new Vector3(0f, 0f, 0f));
            }
        }

        protected abstract void PerformMovement(GameplayController gameplayController, Striker striker, PlayerMovementConstraints playerMovementConstraints);
    }
}

