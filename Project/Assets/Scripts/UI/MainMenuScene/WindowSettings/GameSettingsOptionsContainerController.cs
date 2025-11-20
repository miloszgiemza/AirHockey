using UnityEngine;

namespace UISettings
{
    public class GameSettingsOptionsContainerController : MonoBehaviour
    {
        [SerializeField] private GameObject[] swipeOptions;
        [SerializeField] private GameObject[] snapOptions;

        private void OnEnable()
        {
            UpdateValidOptions();
        }

        public void UpdateValidOptions()
        {
            switch(GameController.Instance.ControlsType)
            {
                case ControlsType.Snap:

                    for(int i = 0; i < swipeOptions.Length; i++)
                    {
                        swipeOptions[i].SetActive(false);
                    }

                    for (int i = 0; i < snapOptions.Length; i++)
                    {
                        snapOptions[i].SetActive(true);
                    }

                    break;

                case ControlsType.Swipe:

                    for (int i = 0; i < snapOptions.Length; i++)
                    {
                        snapOptions[i].SetActive(false);
                    }

                    for (int i = 0; i < swipeOptions.Length; i++)
                    {
                        swipeOptions[i].SetActive(true);
                    }

                    break;
            }
        }
    }
}

