using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : Singleton<GameplayManager> 
{
    [Header("Static Data")]
    [SerializeField] private ItemInformationDatabase itemInformationDatabase;
    [SerializeField] private OrderVisualData orderVisualData;
    [SerializeField] private IngredientVisualData ingredientVisualData;
    [SerializeField] private ChefActivitiesData chefActivitiesData;
    [SerializeField] private float startTime;
    [SerializeField] private bool debugMode;


    [Header("Dynamic Data")]
    [SerializeField] private float currentScore;
    [SerializeField] private float timeLeft;
    [SerializeField] private bool isInit;

    [Header("Event")]
    public UnityEvent<GameplayManager> onInitialize;
    public UnityEvent onGameStart;
    public UnityEvent onGameEnd;
    public ItemInformationDatabase GetItemDatabase => itemInformationDatabase;
    public OrderVisualData GetOrderVisualDatabase => orderVisualData;
    public IngredientVisualData GetIngredientVisualDatabase => ingredientVisualData;
    public ChefActivitiesData GetChefActivitiesData => chefActivitiesData;
    public float CurrentScore => currentScore;
    public float TimeLeft => timeLeft;
    public bool DebugMode => debugMode;

    private void Start()
    {
        if(debugMode)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        isInit = true;
        timeLeft = startTime;
        currentScore = 0f;
        onInitialize?.Invoke(this);
    }

    private void Update()
    {
        if (!isInit) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            onGameEnd?.Invoke();
        }
    }

}
