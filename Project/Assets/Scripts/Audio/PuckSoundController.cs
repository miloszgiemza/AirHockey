using UnityEngine;

namespace Audio
{
    public class PuckSoundController : MonoBehaviour
    {
        [SerializeField] private Puck puck;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == GameObjectsTags.Striker.ToString() || collision.gameObject.tag == GameObjectsTags.Barrier.ToString())
            {
                PlayImpactSoundAccordingToVelocity(puck.CurrentVelocity, puck.CurrentMaxVelocity);
            }
        }

        private void PlayImpactSoundAccordingToVelocity(Vector3 currentVelocity, float maxVelocity)
        {
            if (currentVelocity.x >= maxVelocity / 3f * 2f || currentVelocity.z >= maxVelocity / 3f * 2f)
            {
                AudioPlayer.Instance.PlayEffectSound(SoundsDatabase.Instance[SoundsEffects.StrongImpact]);
            }
            else if(currentVelocity.x >= maxVelocity / 3f || currentVelocity.z >= maxVelocity / 3f)
            {
                AudioPlayer.Instance.PlayEffectSound(SoundsDatabase.Instance[SoundsEffects.NormalImpact]);
            }
            else
            {
                AudioPlayer.Instance.PlayEffectSound(SoundsDatabase.Instance[SoundsEffects.WeakImpact]);
            }
        }
    }
}

