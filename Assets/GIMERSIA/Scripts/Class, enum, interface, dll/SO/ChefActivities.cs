using UnityEngine;

[CreateAssetMenu(fileName = "ChefActivities", menuName = "Scriptable Objects/ChefActivities")]
public class ChefActivities : ScriptableObject
{
    public int id;
    public string activityName;
    public Sprite activityIcon;
    [Tooltip("ini cuma untuk editor doang")]
    [TextArea]
    public string activityDescription;
}
