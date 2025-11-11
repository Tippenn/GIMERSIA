using System.Collections.Generic;
using UnityEngine;

public class CucumberLettuceSalad : MonoBehaviour, IHoldable, IRecipe
{
    [Header("Static Data")]
    [SerializeField] private List<int> ingredientID;
    public List<int> GetIngredientID() => ingredientID;
    public void SetIngredientID(List<int> ingredientID)
    {
        this.ingredientID = ingredientID;
    }
    public GameObject GetGO() => gameObject;


}