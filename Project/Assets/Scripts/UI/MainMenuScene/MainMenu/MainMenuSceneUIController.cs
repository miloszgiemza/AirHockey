using UnityEngine;

using UISettings;
using UIWindowControls;

namespace UIMainMenuScene
{
    public class MainMenuSceneUIController : MonoBehaviour
    {
        [SerializeField] private MainMenuWIndowController mainMenuWIndowController;
        [SerializeField] private WindowSettingsController windowSettingsController;
        [SerializeField] private WindowControlsController windowControlsController;
        [SerializeField] private ChooseGameModeWindowController chooseGameModeWindowController;

        public void ShowMainMenuWindowAndHideOthers()
        {
            mainMenuWIndowController.ShowMainMenuWindow();

            windowSettingsController.HideWindowSettings();
            windowControlsController.HideWindow();
            chooseGameModeWindowController.HideChooseGameModeWindow();
        }

        public void ShowSettingsWindow()
        {
            windowSettingsController.ShowWindowSettings();

            mainMenuWIndowController.HideMainMenuWindow();
            windowControlsController.HideWindow();
            chooseGameModeWindowController.HideChooseGameModeWindow();
        }

        public void ShowControlsWindow()
        {
            windowControlsController.ShowWindow();

            mainMenuWIndowController.HideMainMenuWindow();
            windowSettingsController.HideWindowSettings();
            chooseGameModeWindowController.HideChooseGameModeWindow();
        }

        public void ShowChooseGameModeWindow()
        {
            chooseGameModeWindowController.ShowChooseGameModeWindow();

            mainMenuWIndowController.HideMainMenuWindow();
            windowSettingsController.HideWindowSettings();
            windowControlsController.HideWindow();
        }
    }
}
