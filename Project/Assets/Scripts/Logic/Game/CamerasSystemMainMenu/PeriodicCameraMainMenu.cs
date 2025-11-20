using UnityEngine;
using Unity.Cinemachine;

namespace CamerasSystemMainMenu
{
    public class PeriodicCameraMainMenu : MonoBehaviour
    {
        public float CycleTime => cycleTime;

        private CinemachineCamera cinemachineCamera;

        [SerializeField] private float cycleTime;

        private void Awake()
        {
            cinemachineCamera = GetComponent<CinemachineCamera>();
        }

        public void SetCameraPriority(int newPriority)
        {
            cinemachineCamera.Priority.Value = newPriority;
        }
    }
}

