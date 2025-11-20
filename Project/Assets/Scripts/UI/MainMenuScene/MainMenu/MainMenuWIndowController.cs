using UnityEngine;

namespace UIMainMenuScene
{
    public class MainMenuWIndowController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuWindow;

        public void ShowMainMenuWindow()
        {
            mainMenuWindow.SetActive(true);
        }

        public void HideMainMenuWindow()
        {
            mainMenuWindow.SetActive(false);
        }
    }
}

