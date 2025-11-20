using UnityEngine;

namespace GameplayControllerStateMachine
{
    public class StatePaused : BaseState
    {
        public override StateID StateID => StateID.Paused;

        public override void InitializeState(GameplayController gameplayController)
        {
            Time.timeScale = 0f;
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }
    }
}
