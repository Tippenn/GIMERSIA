using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderVisualizer : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private OrderVisualData orderVisualData;
    [SerializeField] private IngredientVisualData ingredientVisualData;
    [SerializeField] private FoodOrder foodOrder;
    [SerializeField] private GameObject ingredientPrefab;

    [Header("Dynamic Data")]
    [SerializeField] private bool isInit;

    [Header("Reference")]
    [SerializeField] private Image orderImage;
    [SerializeField] private Slider orderTimer;
    [SerializeField] private Transform ingredientParent;
    [SerializeField] private List<Image> ingredientImageList;
    [SerializeField] private List<RectTransform> allRectTransform;

    public void Initialize(FoodOrder foodOrder)
    {
        orderVisualData = GameplayManager.Instance.GetOrderVisualDatabase;
        ingredientVisualData = GameplayManager.Instance.GetIngredientVisualDatabase;
        this.foodOrder = foodOrder;
        AssignVisual();
        RebuildAllLayout();
        isInit = true;

    }

    public void AssignVisual()
    {
        foodOrder.onFoodOrderDelete.AddListener(FoodOrder_OnFoodOrderDelete);
        Debug.Log(foodOrder.ItemInformation.orderID);
        orderImage.sprite = 
            orderVisualData.
            orderList[
                orderVisualData.
                orderList.
                FindIndex(
                    x => 
                    x.orderID == 
                    foodOrder.
                    ItemInformation.
                    orderID
                    )
                ].orderSprite;
        for(int i = 0; i < foodOrder.ItemInformation.ingredientID.Count; i++)
        {
            if (foodOrder.ItemInformation.ingredientID[i] == -1) continue;
            GameObject ingredientGO = Instantiate(ingredientPrefab, ingredientParent);
            Image ingredientImage = ingredientGO.GetComponent<IngredientVisualizer>().IngredientImage;
            ingredientImageList.Add(ingredientImage);
            ingredientImage.sprite = ingredientVisualData.ingredientList[ingredientVisualData.ingredientList.FindIndex(x => x.ingredientID == foodOrder.ItemInformation.ingredientID[i])].ingredientSprite;
        }
    }

    public void RebuildAllLayout()
    {
        foreach(RectTransform rect in allRectTransform)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        }
    }

    private void Update()
    {
        if (!isInit) return;
        if (foodOrder == null) return;
        orderTimer.value =  foodOrder.TimeLeft / foodOrder.MaxTime;
    }

    public void FoodOrder_OnFoodOrderDelete(FoodOrder foodOrder)
    {
        Destroy(gameObject);
    }
}
