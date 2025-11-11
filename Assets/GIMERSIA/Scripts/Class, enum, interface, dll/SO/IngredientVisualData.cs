using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientVisualData", menuName = "Scriptable Objects/IngredientVisualData")]
public class IngredientVisualData : ScriptableObject
{
    public List<IngredientVisual> ingredientList;
}
