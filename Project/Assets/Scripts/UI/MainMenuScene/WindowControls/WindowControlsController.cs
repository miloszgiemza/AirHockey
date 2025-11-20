using UnityEngine;

namespace UIWindowControls
{
    public class WindowControlsController : MonoBehaviour
    {
        [SerializeField] private GameObject windowControls;

        public void ShowWindow()
        {
            windowControls.SetActive(true);
        }

        public void HideWindow()
        {
            windowControls.SetActive(false);
        }
    }
}
