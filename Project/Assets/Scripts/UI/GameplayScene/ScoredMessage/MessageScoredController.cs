using UnityEngine;
using TMPro;
using System.Collections;

using Players;
using GameEvents;

namespace UIGameplayScene
{
    public class MessageScoredController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMessageUI;

        private Color colorPlayer1 = new Color32(0, 46, 245, 255);
        private Color colorPlayer2 = new Color32(255, 0, 0, 255);

        private float messageTime = 0.4f;

        private void OnEnable()
        {
            EventsGameplayUI.OnPlayerScored += ShowMessage;
        }

        private void OnDisable()
        {
            EventsGameplayUI.OnPlayerScored -= ShowMessage;

            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void ShowMessage(PlayerSide goalWhichWasScored)
        {
            textMessageUI.gameObject.SetActive(true);

            switch(goalWhichWasScored)
            {
                case PlayerSide.Player1:
                    textMessageUI.color = colorPlayer2;
                    textMessageUI.text = PlayerSide.Player2.ToString() + " scored!";
                    break;

                case PlayerSide.Player2:
                    textMessageUI.color = colorPlayer1;
                    textMessageUI.text = PlayerSide.Player1.ToString() + " scored!";
                    break;
            }

            

            StartCoroutine(HideMessageAfterTime());
        }

        private IEnumerator HideMessageAfterTime()
        {
            yield return new WaitForSeconds(messageTime);
            textMessageUI.gameObject.SetActive(false);
        }
    }
}

