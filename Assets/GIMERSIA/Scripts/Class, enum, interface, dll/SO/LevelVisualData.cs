using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelVisualData", menuName = "Scriptable Objects/LevelVisualData")]
public class LevelVisualData : ScriptableObject
{
    public List<LevelVisual> levelVisualList;
}
