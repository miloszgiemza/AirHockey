using UnityEngine;

namespace UIMainMenuScene
{
    public class ChooseGameModeWindowController : MonoBehaviour
    {
        [SerializeField] private GameObject chooseGameModeWindow;

        public void ShowChooseGameModeWindow()
        {
            chooseGameModeWindow.SetActive(true);
        }

        public void HideChooseGameModeWindow()
        {
            chooseGameModeWindow.SetActive(false);
        }
    }
}

