using System.Collections.Generic;
using UnityEngine;

public class OrderVisualManager : Singleton<OrderVisualManager>
{
    [Header("Static Data")]
    [SerializeField] private GameObject orderVisualizerPrefab;
    [Header("dynamic Data")]
    [SerializeField] private List<GameObject> orderVisualizerList;
    [Header("Reference")]
    [SerializeField] private Transform orderVisualizerParent;
    public void FoodOrderSystem_OnOrderGenerated(FoodOrder foodOrder)
    {
        GameObject prefab = Instantiate(orderVisualizerPrefab, orderVisualizerParent);
        OrderVisualizer orderVisualizer = prefab.GetComponent<OrderVisualizer>();
        orderVisualizer.Initialize(foodOrder);
    }
}
