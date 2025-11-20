using UnityEngine;

using UIBaseClasses;
using GameSettingsAndSaveSystem;

namespace UISettings
{
    public class SliderPuckMaximumSpeed : BaseSlider
    {
        private Puck puck;

        protected override void Awake()
        {
            base.Awake();

            puck = FindFirstObjectByType<Puck>();

            slider.minValue = puck.MinMaxVelocity;
            slider.maxValue = puck.MaxMaxVelocity;
            slider.value = GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.PuckMaxSpeed, puck.DefaultMaxVelocity);
        }

        protected override void DoThisWhenPlayerSlidesSlider(float sliderNewValue)
        {
            GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.PuckMaxSpeed, sliderNewValue);
        }
    }
}

