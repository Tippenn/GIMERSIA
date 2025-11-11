using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderVisual", menuName = "Scriptable Objects/OrderVisual")]
public class OrderVisual : ScriptableObject
{
    public string orderName;
    public int orderID;
    public Sprite orderSprite;
}
