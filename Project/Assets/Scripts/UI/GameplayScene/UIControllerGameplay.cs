using UnityEngine;

using Players;

namespace UIGameplayScene
{
    public class UIControllerGameplay : MonoBehaviour
    {
        [SerializeField] private WindowVictoryController windowVictory;
        [SerializeField] private GameObject windowInGameMenu;
        [SerializeField] private GameObject windowTutorial;

        public void ShowVictoryWindow(PlayerSide playerWhoHasWon)
        {
            windowVictory.gameObject.SetActive(true);
            windowVictory.GenerateText(playerWhoHasWon);
        }

        public void ShowInGameMenuWindow()
        {
            windowInGameMenu.SetActive(true);
        }

        public void HideInGameMenuWindow()
        {
            windowInGameMenu.SetActive(false);
        }

        public void  ShowTutorialWindow()
        {
            windowTutorial.SetActive(true);
        }

        public void HideTutorialWindow()
        {
            windowTutorial.SetActive(false);
        }
    }
}
