using UnityEngine;
using UnityEngine.UI;

namespace UIMainMenuScene
{
    public class ChooseGameModeWindow : MonoBehaviour
    {
        [SerializeField] private Button buttonTwoPlayerMode;
        [SerializeField] private Button buttonVersusComputerMode;

        private Color colorActive = new Color32(0, 46, 245, 255);
        private Color colorInactive = new Color32(0, 46, 245, 47);

        private void OnEnable()
        {
            MarkGameModeButtonsAsActiveOrNot();
        }

        public void MarkGameModeButtonsAsActiveOrNot()
        {
            ColorBlock colorsButtonActiveMode = buttonTwoPlayerMode.colors;
            colorsButtonActiveMode.normalColor = colorActive;
            colorsButtonActiveMode.highlightedColor = colorActive;
            
            ColorBlock colorsButtonInactiveMode = buttonTwoPlayerMode.colors;
            colorsButtonInactiveMode.normalColor = colorInactive;
            colorsButtonInactiveMode.highlightedColor = colorActive; ;

            switch(GameController.Instance.GameMode)
            {
                case GameMode.TwoPlayers:

                    buttonTwoPlayerMode.colors = colorsButtonActiveMode;
                    buttonVersusComputerMode.colors = colorsButtonInactiveMode;

                    break;

                case GameMode.Computer:

                    buttonTwoPlayerMode.colors = colorsButtonInactiveMode;
                    buttonVersusComputerMode.colors = colorsButtonActiveMode;

                    break;
            }
        }
    }
}
