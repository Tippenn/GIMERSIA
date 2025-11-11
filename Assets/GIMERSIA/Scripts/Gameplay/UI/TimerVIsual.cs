using TMPro;
using UnityEngine;

public class TimerVIsual : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private GameplayManager gameplayManager;

    [Header("Reference")]
    [SerializeField] private TMP_Text timerText;

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
    }
    private void Update()
    {
        timerText.text = gameplayManager.TimeLeft.ToString("F0");
    }
}
