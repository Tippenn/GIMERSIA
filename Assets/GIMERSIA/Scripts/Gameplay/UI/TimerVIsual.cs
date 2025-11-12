using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerVIsual : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private GameplayManager gameplayManager;

    [Header("Reference")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Slider timerSlider;

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
    }
    private void Update()
    {
        timerText.text = ConvertTime(gameplayManager.TimeLeft);
        timerSlider.value = gameplayManager.TimeLeft / gameplayManager.StartTime;

    }

    private string ConvertTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
    }
}
