using System.Collections.Generic;
using UnityEngine;

public class ChoppedLettuce : MonoBehaviour, IHoldable, IRecipe
{
    [Header("Static Data")]
    [SerializeField] private List<int> ingredientID;
    public List<int> GetIngredientID() => ingredientID;
    public GameObject GetGO() => gameObject;


}