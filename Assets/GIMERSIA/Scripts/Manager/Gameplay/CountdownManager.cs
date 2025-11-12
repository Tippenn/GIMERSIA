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
    [SerializeField] private bool isInit;
    
    [Header("Reference")]
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject countdownPanel;

    [Header("Event")]
    [SerializeField] private UnityEvent onCountdownFinish;

    private void Start()
    {
        currentCountdown = countdownTime;
    }

    public void Initialize()
    {
        countdownPanel.SetActive(true);
        isInit = true;
        
    }

    private void Update()
    {
        if (!isInit) return;
        if (currentCountdown <= 0 && countdownFinish) return;
        currentCountdown -= Time.deltaTime;
        if(currentCountdown <= 1f)
        {
            countdownText.text = "GOOO!!";
        }
        else
        {
            countdownText.text = (Mathf.CeilToInt(currentCountdown) - 1).ToString("F0");
        }
        
        if(currentCountdown < 0 && !countdownFinish)
        {
            countdownPanel.SetActive(false);
            onCountdownFinish?.Invoke();
            countdownFinish = true;
        }
    }

}
