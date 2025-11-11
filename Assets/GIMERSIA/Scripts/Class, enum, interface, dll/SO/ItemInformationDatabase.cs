using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInformationDatabase", menuName = "Scriptable Objects/ItemInformationDatabase")]
public class ItemInformationDatabase : ScriptableObject
{
    public List<ItemInformation> itemData;
}
