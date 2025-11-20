using UnityEngine;
using System;

using UIBaseClasses;

namespace UIMainMenuScene
{
    public class InputFieldScoreToWin : BaseInputField
    {
        public int ReturnScoreToWin()
        {
            return Convert.ToInt32(inputField.text);
        }
    }
}

