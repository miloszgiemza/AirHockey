using UnityEngine;
using System.Collections;
using TMPro;

using GameEvents;


namespace UIGameplayScene
{
    public class CountdownController : MonoBehaviour
    {
        private TextMeshProUGUI textUI;

        private void Awake()
        {
            textUI = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventsGameplayUI.OnCountdown += PerformCountdown;
        }

        private void OnDisable()
        {
            EventsGameplayUI.OnCountdown -= PerformCountdown;

            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void PerformCountdown(float overallTime)
        {
            StartCoroutine(Countdown(overallTime));
        }

        private IEnumerator Countdown(float overallTime)
        {
            textUI.text = "3";
            yield return new WaitForSeconds(overallTime / 3f);
            textUI.text = "2";
            yield return new WaitForSeconds(overallTime / 3f);
            textUI.text = "1";
            yield return new WaitForSeconds(overallTime / 3f);
            textUI.text = "";
            
        }
    }
}

