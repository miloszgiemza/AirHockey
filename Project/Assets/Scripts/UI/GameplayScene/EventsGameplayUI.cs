using UnityEngine;
using System;

using Players;

namespace GameEvents
{
    public static class EventsGameplayUI
    {
        public static Action<int> OnUpdatePlayer1Score;
        public static Action<int> OnUpdatePlayer2Score;

        public static Action<PlayerSide> OnPlayerScored;

        public static Action<float> OnCountdown;
    }
}

