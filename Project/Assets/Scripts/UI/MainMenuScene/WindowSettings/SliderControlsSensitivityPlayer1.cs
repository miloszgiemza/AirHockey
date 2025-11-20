using UnityEngine;

using UIBaseClasses;
using GameSettingsAndSaveSystem;


namespace UISettings
{
    public class SliderControlsSensitivityPlayer1 : BaseSlider
    {
        private Striker striker;

        protected override void Awake()
        {
            base.Awake();
            striker = FindFirstObjectByType<Striker>();

            slider.minValue = striker.MinMovementSpeedModifier;
            slider.maxValue = striker.MaxMovmentSpeedModifier;
            slider.value = GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ControlsSensitivityPlayer1, striker.DefaultMovementSpeedModifier);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ControlsSensitivityPlayer1, slider.value);
        }

        protected override void DoThisWhenPlayerSlidesSlider(float sliderNewValue)
        {
            GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.ControlsSensitivityPlayer1, sliderNewValue);
        }
    }
}

