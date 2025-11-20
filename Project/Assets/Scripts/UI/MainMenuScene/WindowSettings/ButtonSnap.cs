using UnityEngine;

using UIBaseClasses;

namespace UISettings
{
    public class ButtonSnap : BaseButton
    {
        [SerializeField] private GameSettingsOptionsContainerController gameSettingsOptionsContainerController;
        [SerializeField] private WindowSettingsActiveControlsTypeButtonHighlighter windowSettingsActiveControlsTypeButtonHighlighter;

        protected override void DoThisOnClick()
        {
            GameController.Instance.SwitchControlsTypeToSnap();
            windowSettingsActiveControlsTypeButtonHighlighter.MarkActiveControlsTypeButtonAsActiveOrNot(GameController.Instance.ControlsType);
            gameSettingsOptionsContainerController.UpdateValidOptions();
        }
    }
}

