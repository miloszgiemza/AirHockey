using UnityEngine;

using GameEvents;
using Audio;

namespace GameplayControllerStateMachine
{
    public class StateResetPuck : BaseState
    {
        public override StateID StateID => StateID.ResetPuck;

        private float countdownTime = 1.15f;

        private float timer;

        public override void InitializeState(GameplayController gameplayController)
        {
            timer = 0f;
            gameplayController.Puck.gameObject.SetActive(false);
            EventsGameplayUI.OnCountdown?.Invoke(countdownTime);
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
            timer += Time.deltaTime;

            if(timer >= countdownTime)
            {
                gameplayController.Puck.transform.position = gameplayController.Table.DefaultPuckPosition;
                gameplayController.Puck.gameObject.SetActive(true);
                AudioPlayer.Instance.PlayEffectSound(SoundsDatabase.Instance[SoundsEffects.PuckBackInGame]);
                gameplayController.SwitchState(StateID.Playing);
            }
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }
    }
}

