using UnityEngine;

using GameHardwareAndInputClasses;

public class Debugger : MonoBehaviour
{
    private GameplayController gameplayController;

    private void Update()
    {
        if(PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer1SideOfScreen(InputController.Instance.PrimaryTouchPosition) &&
            PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer2SideOfScreen(InputController.Instance.PrimaryTouchPosition))
        {
            Debug.Log("Primary touch na obu: " + InputController.Instance.PrimaryTouchPosition.x + " / "  + InputController.Instance.PrimaryTouchPosition.y);
        }

        if (PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer1SideOfScreen(InputController.Instance.SecondaryTouchPosition) &&
        PlayersHotseatScreenSpaceController.CheckIfInputOnPlayer2SideOfScreen(InputController.Instance.SecondaryTouchPosition))
        {
            Debug.Log("Secondary touch na obu: " + InputController.Instance.SecondaryTouchPosition.x + " / " + InputController.Instance.SecondaryTouchPosition.y);
        }
    }
}
