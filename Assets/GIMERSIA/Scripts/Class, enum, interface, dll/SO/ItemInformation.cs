using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemInformation", menuName = "Scriptable Objects/ItemInformation")]
public class ItemInformation : ScriptableObject
{
    public string itemName;
    public int itemID;
    public GameObject itemPrefab;
    public int orderID;
    public List<int> ingredientID;
}
