using UnityEngine;

using TMPro;

namespace UIBaseClasses
{
    public abstract class BaseInputField : MonoBehaviour
    {
        protected TMP_InputField inputField;

        protected virtual void Awake()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public string ReturnInputFieldText()
        {
            return inputField.text;
        }
    }
}

