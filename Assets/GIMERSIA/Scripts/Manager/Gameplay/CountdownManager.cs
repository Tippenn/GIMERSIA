using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownManager : Singleton<CountdownManager>
{
    [Header("Static Data")]
    [SerializeField] private float countdownTime;

    [Header("Dynamic Data")]
    [SerializeField] private float currentCountdown;
    [SerializeField] private bool countdownFinish;
    
    [Header("Reference")]
    [SerializeField] private TMP_Text countdownText;

    [Header("Event")]
    [SerializeField] private UnityEvent onCountdownFinish;

    private void Start()
    {
        currentCountdown = countdownTime;
    }

    private void Update()
    {
        if (currentCountdown < 0 && countdownFinish) return;
        currentCountdown -= Time.deltaTime;
        if(currentCountdown < 0 && !countdownFinish)
        {
            onCountdownFinish?.Invoke();
            countdownFinish = true;
        }
    }

}
