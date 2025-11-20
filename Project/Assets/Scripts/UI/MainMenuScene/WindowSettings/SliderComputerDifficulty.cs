using UnityEngine;

using UIBaseClasses;
using Players;
using GameSettingsAndSaveSystem;

namespace UISettings
{
    public class SliderComputerDifficulty : BaseSlider
    {
        protected override void Awake()
        {
            base.Awake();
            slider.minValue = BasePlayerComputer.MinComputerDifficulty;
            slider.maxValue = BasePlayerComputer.MaxComputerDifficulty;
            slider.value = GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.ComputerDifficulty, BasePlayerComputer.DefaultComputerDifficulty);
        }

        protected override void DoThisWhenPlayerSlidesSlider(float sliderNewValue)
        {
            GameSettings.Instance.SetSetting(GameSettings.SettingsOptions.ComputerDifficulty, sliderNewValue);
        }
    }
}
