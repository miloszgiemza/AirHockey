using UnityEngine;

using UIBaseClasses;

namespace UISettings
{
    public class ButtonSwipe : BaseButton
    {
        [SerializeField] private GameSettingsOptionsContainerController gameSettingsOptionsContainerController;
        [SerializeField] private WindowSettingsActiveControlsTypeButtonHighlighter windowSettingsActiveControlsTypeButtonHighlighter;

        protected override void DoThisOnClick()
        {
            GameController.Instance.SwitchControlsTypeToSwipe();
            windowSettingsActiveControlsTypeButtonHighlighter.MarkActiveControlsTypeButtonAsActiveOrNot(GameController.Instance.ControlsType);
            gameSettingsOptionsContainerController.UpdateValidOptions();
        }
    }
}
