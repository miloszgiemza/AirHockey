using UnityEngine;
using UnityEngine.UI;

namespace UIBaseClasses
{
    public abstract class BaseSlider : MonoBehaviour
    {
        protected Slider slider;

        protected virtual void Awake()
        {
            slider = GetComponent<Slider>();
        }

        protected virtual void OnEnable()
        {
            slider.onValueChanged.AddListener(DoThisWhenPlayerSlidesSlider);
        }

        protected virtual void OnDisable()
        {
            slider.onValueChanged.RemoveListener(DoThisWhenPlayerSlidesSlider);
        }

        protected abstract void DoThisWhenPlayerSlidesSlider(float sliderNewValue);
    }
}
