using UnityEngine;

namespace GameplayControllerStateMachine
{
    public enum StateID
    {
        Initialize,
        Intro,
        Paused,
        Playing,
        Scored,
        ResetPuck,
        Victory
    }

    public abstract class BaseState
    {
        public abstract StateID StateID { get; }
        public abstract void InitializeState(GameplayController gameplayController);
        public abstract void RunUpdate(GameplayController gameplayController);
        public abstract void RunFixedUpdate(GameplayController gameplayController);
    }
}

