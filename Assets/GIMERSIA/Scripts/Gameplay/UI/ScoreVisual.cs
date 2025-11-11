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
    }
    private void Update()
    {
        scoreText.text = gameplayManager.CurrentScore.ToString();
    }
}
