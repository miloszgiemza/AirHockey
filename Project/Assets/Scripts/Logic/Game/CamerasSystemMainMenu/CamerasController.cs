using Unity.Cinemachine;
using UnityEngine;

namespace CamerasSystemMainMenu
{
    public class CamerasController : MonoBehaviour
    {
        [SerializeField] private PeriodicCameraMainMenu[] cameras;

        private int currentCamera = 0;
        private float currentTimer = 0f;

        private int priorityCurrentCamera = 100;
        private int prioritySleepingCamera = 0;

        private void Awake()
        {
            cameras[0].gameObject.SetActive(true);
        }

        private void Update()
        {
            CycleThroughCameras(cameras);
        }

        private void CycleThroughCameras(PeriodicCameraMainMenu[] cameras)
        {
            cameras[currentCamera].SetCameraPriority(prioritySleepingCamera);
            currentTimer += Time.deltaTime;

            if(currentTimer >= cameras[currentCamera].CycleTime)
            {
                currentTimer = 0f;

                if ((currentCamera + 1) < cameras.Length) currentCamera++;
                else currentCamera = 0;

                cameras[currentCamera].SetCameraPriority(priorityCurrentCamera);
            }
        }
    }
}
