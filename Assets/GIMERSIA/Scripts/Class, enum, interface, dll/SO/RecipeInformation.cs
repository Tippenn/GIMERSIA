using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeInformation", menuName = "Scriptable Objects/RecipeInformation")]
public class RecipeInformation : ScriptableObject
{
    public string recipeName;
    public GameObject recipePrefab;
    public int recipeID;
    public List<int> ingredientIDList;
}