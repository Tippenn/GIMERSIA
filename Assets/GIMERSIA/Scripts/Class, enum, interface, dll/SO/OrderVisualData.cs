using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderVisualData", menuName = "Scriptable Objects/OrderVisualData")]
public class OrderVisualData : ScriptableObject
{
    public List<OrderVisual> orderList;
}
