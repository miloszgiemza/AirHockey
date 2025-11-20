using UnityEngine;
using UnityEngine.UI;

using Audio;

namespace UIBaseClasses
{
    public abstract class BaseButton : MonoBehaviour
    {
        protected Button button;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            button.onClick.AddListener(CommonOnClickActions);
        }

        protected void OnDisable()
        {
            button.onClick.RemoveListener(CommonOnClickActions);
        }

        protected virtual void CommonOnClickActions()
        {
            DoThisOnClick();
            AudioPlayer.Instance.PlayUISound(SoundsDatabase.Instance[SoundsUI.Button]);
        }
        protected abstract void DoThisOnClick();
    }
}

