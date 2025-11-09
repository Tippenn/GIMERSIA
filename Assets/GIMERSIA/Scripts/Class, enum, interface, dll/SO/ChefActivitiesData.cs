using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChefActivitiesData", menuName = "Scriptable Objects/ChefActivitiesData")]
public class ChefActivitiesData : ScriptableObject
{
    public List<ChefActivities> chefActivityList;
}
