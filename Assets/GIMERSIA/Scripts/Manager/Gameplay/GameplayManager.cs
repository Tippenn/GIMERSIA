using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : Singleton<GameplayManager> 
{
    [Header("Static Data")]
    [SerializeField] private ItemInformationDatabase itemInformationDatabase;
    [SerializeField] private OrderVisualData orderVisualData;
    [SerializeField] private IngredientVisualData ingredientVisualData;
    [SerializeField] private ChefActivitiesData chefActivitiesData;
    [SerializeField] private List<int> possibleOrder;
    [SerializeField] private float startTime;
    [SerializeField] private float baseOrderScore;
    [SerializeField] private bool debugMode;


    [Header("Dynamic Data")]
    [SerializeField] private float currentScore;
    [SerializeField] private float timeLeft;
    [SerializeField] private bool isInit;
    [SerializeField] private bool gameEnded;

    [Header("Event")]
    public UnityEvent<GameplayManager> onInitialize;
    public UnityEvent onStatChange;
    public UnityEvent onGameStart;
    public UnityEvent onGameEnd;
    public ItemInformationDatabase GetItemDatabase => itemInformationDatabase;
    public OrderVisualData GetOrderVisualDatabase => orderVisualData;
    public IngredientVisualData GetIngredientVisualDatabase => ingredientVisualData;
    public ChefActivitiesData GetChefActivitiesData => chefActivitiesData;
    public List<int> PossibleOrder => possibleOrder;
    public float BaseOrderScore => baseOrderScore;
    public float CurrentScore => currentScore;
    public float StartTime => startTime;
    public float TimeLeft => timeLeft;
    public bool DebugMode => debugMode;

    private void Start()
    {
        timeLeft = startTime;
        if (debugMode)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        AudioManager.Instance.UnPauseBGM();
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.gameplayBGM);
        isInit = true;
        timeLeft = startTime;
        currentScore = 0f;
        onInitialize?.Invoke(this);
    }

    private void Update()
    {
        if (!isInit || gameEnded) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0 && !gameEnded)
        {
            gameEnded = true;
            StartCoroutine(EndGame());
        }
    }

    public void AddScore(float score)
    {
        if (!isInit) return;
        currentScore += score;
        onStatChange?.Invoke();
    }

    public IEnumerator EndGame()
    {
        timeLeft = 0f;
        yield return null;
        onGameEnd?.Invoke();
    }

}
