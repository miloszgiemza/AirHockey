using UnityEngine;
using Unity.Cinemachine;

namespace CamerasSystemMainMenu
{
    public class CameraOrbitingController : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera cinemachineCamera;
        [SerializeField] private CinemachineOrbitalFollow cinemachineOrbitalFollow;
        [SerializeField] private float movementSpeed = 0.08f;

        private void FixedUpdate()
        {
            MoveOnOrbitHorizontally();
        }

        private void MoveOnOrbitHorizontally()
        {
            cinemachineOrbitalFollow.HorizontalAxis.Value = cinemachineOrbitalFollow.HorizontalAxis.Value + movementSpeed;
        }
    }
}

