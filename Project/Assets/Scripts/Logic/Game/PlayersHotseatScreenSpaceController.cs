using UnityEngine;

namespace GameHardwareAndInputClasses
{
    public static class PlayersHotseatScreenSpaceController
    {

        public static bool CheckIfInputOnPlayer1SideOfScreen(Vector2 inputPos)
        {
            bool isOnPlayer1Side = false;

            if (inputPos.y < Screen.height / 2f) isOnPlayer1Side = true;

            return isOnPlayer1Side;
        }

        public static bool CheckIfInputOnPlayer2SideOfScreen(Vector2 inputPos)
        {
            bool isOnPlayer2Side = false;

            if (inputPos.y > Screen.height / 2f) isOnPlayer2Side = true;

            return isOnPlayer2Side;
        }
    }
}
