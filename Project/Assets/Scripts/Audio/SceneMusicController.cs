using UnityEngine;

namespace Audio
{
    public class SceneMusicController : MonoBehaviour
    {
        [SerializeField] private SoundsMusic sceneMusic;

        private void Start()
        {
            AudioPlayer.Instance.PlayMusic(SoundsDatabase.Instance[sceneMusic]);
        }
    }
}

