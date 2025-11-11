using System.Collections.Generic;
using UnityEngine;

public interface IRecipe
{
    void SetIngredientID(List<int> ingredientID);   
    List<int> GetIngredientID();
}
