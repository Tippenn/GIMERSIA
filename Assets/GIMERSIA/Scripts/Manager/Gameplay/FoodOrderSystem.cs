using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodOrderSystem : Singleton<FoodOrderSystem>
{
    [Header("Static Data")]
    [SerializeField] private ItemInformationDatabase itemDatabase;
    [SerializeField] private GameObject orderPrefab;
    [SerializeField] private int maxOrder;
    [SerializeField] private float orderInterval;
    [SerializeField] private float timeForEachOrder;

    [Header("Dynamic Data")]
    [SerializeField] private List<FoodOrder> orders;
    [SerializeField] private bool isInit = false;
    [SerializeField] private float currentIntervalTime;

    [Header("Reference")]
    [SerializeField] private Transform orderParent;

    [Header("Event")]
    public UnityEvent<FoodOrder> onOrderFulfilled;
    public UnityEvent<FoodOrder> onOrderGenerated;

    protected override void Awake()
    {
        base.Awake();
        orders = new List<FoodOrder>();
    }

    private void Start()
    {

    }

    public void Initialize(GameplayManager gameplayManager)
    {
        isInit = true;
        currentIntervalTime = orderInterval - 5f;
    }

    public void Update()
    {
        if (!isInit) return;
        currentIntervalTime += Time.deltaTime;
        if(currentIntervalTime > orderInterval && orders.Count < maxOrder)
        {
            currentIntervalTime = 0f;
            GenerateOrder();
        }

        
    }

    public void GenerateOrder()
    {
        ItemInformation itemOrder;
        int index = Random.Range(0, GameplayManager.Instance.PossibleOrder.Count);
        int orderID = GameplayManager.Instance.PossibleOrder[index];
        itemOrder = itemDatabase.itemData[itemDatabase.itemData.FindIndex(x => x.orderID == orderID)];
        
        GameObject foodOrderGO = Instantiate(orderPrefab,orderParent);
        FoodOrder foodOrder = foodOrderGO.GetComponent<FoodOrder>();
        foodOrder.onFoodOrderDelete.AddListener(FoodOrder_OnFoodOrderDelete);
        foodOrder.Initialize(itemOrder, timeForEachOrder, this);
        
        orders.Add(foodOrder);
        onOrderGenerated?.Invoke(foodOrder);
    }

    public void FoodOrder_OnFoodOrderDelete(FoodOrder foodOrder)
    {
        orders.Remove(foodOrder);
    }

    public void GiveItem(IRecipe recipe)
    {
        for(int i = 0;i < orders.Count; i++)
        {
            List<int> ingredientList = orders[i].ItemInformation.ingredientID;
            if (HaveSameElements(ingredientList, recipe.GetIngredientID()) == true)
            {
                AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.cashRegister);
                onOrderFulfilled?.Invoke(orders[i]);
                Debug.Log("Have Same Element");
            }
        }
    }
    
    private bool HaveSameElements(List<int> listA, List<int> listB)
    {
        if (listA.Count != listB.Count)
            return false;

        // Sort both and compare element by element
        listA.Sort();
        listB.Sort();

        for (int i = 0; i < listA.Count; i++)
        {
            if (listA[i] != listB[i])
                return false;
        }

        return true;
    }
}
