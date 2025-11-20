using UnityEngine;

using Players;
using Audio;
using GameEvents;

public class Goal : MonoBehaviour
{
    [SerializeField] private PlayerSide playerSide;

    private bool scored = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == GameObjectsTags.Puck.ToString())
        {
            scored = true;
            if(!ReferenceEquals(EventsGameplayUI.OnPlayerScored, null))EventsGameplayUI.OnPlayerScored.Invoke(playerSide);
            AudioPlayer.Instance.PlayEffectSound(SoundsDatabase.Instance[SoundsEffects.GoalScored]);
        }
    }

    public bool RunGoal()
    {
        return scored;
    }

    public void ResetGoal()
    {
        scored = false;
    }
}
