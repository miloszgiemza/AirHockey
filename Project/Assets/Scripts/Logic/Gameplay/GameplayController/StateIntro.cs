using UnityEngine;

using GameSettingsAndSaveSystem;

namespace GameplayControllerStateMachine
{
    public class StateIntro : BaseState
    {
        public override StateID StateID => StateID.Intro;

        public override void InitializeState(GameplayController gameplayController)
        {
            gameplayController.SwitchState(StateID.ResetPuck);

            /*
            if( !GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.TutorialPlayed, false) )
            {
                GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.TutorialPlayed, true);
                Time.timeScale = 0f;
                gameplayController.UIControllerGameplay.ShowTutorialWindow();
            }
            else
            {
                gameplayController.SwitchState(StateID.Playing);
            }
            */
        }

        public override void RunUpdate(GameplayController gameplayController)
        {
        }

        public override void RunFixedUpdate(GameplayController gameplayController)
        {
        }
    }
}

