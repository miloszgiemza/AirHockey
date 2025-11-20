using UnityEngine;
using TMPro;

using Players;

namespace UIGameplayScene
{
    public class WindowVictoryController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiTitleText;
        [SerializeField] private TextMeshProUGUI uiWindowText;

        private Color colorPlayer1 = new Color32(0, 46, 245, 255);
        private Color colorPlayer2 = new Color32(255, 0, 0, 255);

        private string text = " has won!";
        
        public void GenerateText(PlayerSide playerWhoWon)
        {
            uiWindowText.text = playerWhoWon.ToString() + text;

            switch(playerWhoWon)
            {
                case PlayerSide.Player1:
                    uiTitleText.color = colorPlayer1;
                    uiWindowText.color = colorPlayer1;
                    break;

                case PlayerSide.Player2:
                    uiTitleText.color = colorPlayer2;
                    uiWindowText.color = colorPlayer2;
                    break;
            }
        }
    }
}
