using UnityEngine;
using TMPro;

using GameEvents;

namespace UIGameplayScene
{
    public class PointsCountersController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsCounterPlayer1;
        [SerializeField] private TextMeshProUGUI pointsCounterPlayer2;

        private void Awake()
        {
            ReversePlayer2ScoreTextIfPlayerHuman2();
        }

        private void OnEnable()
        {
            EventsGameplayUI.OnUpdatePlayer1Score += UpdatePlayer1Score;
            EventsGameplayUI.OnUpdatePlayer2Score += UpdatePlayer2Score;
        }

        private void OnDisable()
        {
            EventsGameplayUI.OnUpdatePlayer1Score -= UpdatePlayer1Score;
            EventsGameplayUI.OnUpdatePlayer2Score -= UpdatePlayer2Score;
        }

        public void UpdatePlayer1Score(int newScore)
        {
            pointsCounterPlayer1.text = "Player 1 Score: " + newScore.ToString();
        }

        public void UpdatePlayer2Score(int newScore)
        {
            pointsCounterPlayer2.text = "Player 2 Score: " + newScore.ToString();
        }

        private void ReversePlayer2ScoreTextIfPlayerHuman2()
        {
            if(GameController.Instance.GameMode == GameMode.TwoPlayers)
            {
                pointsCounterPlayer2.transform.Rotate(0f, 0f, 180f);
                pointsCounterPlayer2.transform.position = new Vector3(pointsCounterPlayer2.transform.position.x, pointsCounterPlayer2.transform.position.y - 110f, 
                    pointsCounterPlayer2.transform.position.z);
            }
        }
    }
}

