using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private GameplayManager gameplayManager;

    [Header("Reference")]
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
        gameplayManager.onStatChange.AddListener(OnStatChange_ChangeCoinAmount);
    }

    public void OnStatChange_ChangeCoinAmount()
    {
        scoreText.text = gameplayManager.CurrentScore.ToString("F0");
    }
}
