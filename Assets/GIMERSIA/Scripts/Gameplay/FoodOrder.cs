using UnityEngine;
using UnityEngine.Events;

public class FoodOrder : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private ItemInformation itemInformation;
    [SerializeField] private float maxTime;

    [Header("Dynamic Data")]
    [SerializeField] private bool isInit;
    [SerializeField] private float timeLeft;

    [Header("Event")]
    public UnityEvent<FoodOrder> onFoodOrderDelete;

    public ItemInformation ItemInformation
    {
        get { return itemInformation; }
        set
        {
            itemInformation = value;
        }
    }
    public float TimeLeft => timeLeft;
    public float MaxTime => maxTime;
    public void Initialize(ItemInformation itemInformation, float timeLeft, FoodOrderSystem foodOrderSystem)
    {
        isInit = true;
        this.itemInformation = itemInformation;
        this.timeLeft = timeLeft;
        maxTime = timeLeft;
        foodOrderSystem.onOrderFulfilled.AddListener(FoodOrderSystem_OnOrderFulfilled); 
    }

    private void Update()
    {
        if (!isInit) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            onFoodOrderDelete?.Invoke(this);
            Destroy(gameObject);
        }
    }

    private void FoodOrderSystem_OnOrderFulfilled(FoodOrder foodOrder)
    {
        if(foodOrder == this)
        {
            float scoreAddAmount = GameplayManager.Instance.BaseOrderScore * (itemInformation.ingredientID.Count-1) + (GameplayManager.Instance.BaseOrderScore * (timeLeft/maxTime) * 2);
            GameplayManager.Instance.AddScore(scoreAddAmount);
            onFoodOrderDelete?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
