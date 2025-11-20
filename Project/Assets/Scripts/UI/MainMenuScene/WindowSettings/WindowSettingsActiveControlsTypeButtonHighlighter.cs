using UnityEngine;

using UnityEngine.UI;

namespace UISettings
{
    public class WindowSettingsActiveControlsTypeButtonHighlighter : MonoBehaviour
    {
        [SerializeField] private Button buttonSnap;
        [SerializeField] private Button buttonSwipe;

        private Color colorActive = new Color32(0, 46, 245, 255);
        private Color colorInactive = new Color32(0, 46, 245, 47);

        private void OnEnable()
        {
            MarkActiveControlsTypeButtonAsActiveOrNot(GameController.Instance.ControlsType);
        }

        public void MarkActiveControlsTypeButtonAsActiveOrNot(ControlsType controlsType)
        {
            ColorBlock colorsButtonActiveMode = buttonSnap.colors;
            colorsButtonActiveMode.normalColor = colorActive;
            colorsButtonActiveMode.highlightedColor = colorActive;

            ColorBlock colorsButtonInactiveMode = buttonSwipe.colors;
            colorsButtonInactiveMode.normalColor = colorInactive;
            colorsButtonInactiveMode.highlightedColor = colorActive; 

            switch (controlsType)
            {
                case ControlsType.Snap:

                    buttonSnap.colors = colorsButtonActiveMode;
                    buttonSwipe.colors = colorsButtonInactiveMode;

                    break;

                case ControlsType.Swipe:

                    buttonSnap.colors = colorsButtonInactiveMode;
                    buttonSwipe.colors = colorsButtonActiveMode;

                    break;
            }
        }
    }
}
