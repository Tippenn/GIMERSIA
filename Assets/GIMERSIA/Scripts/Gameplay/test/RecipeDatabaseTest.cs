using MyBox;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabaseTest : MonoBehaviour
{
    public List<int> recipeA;
    public List<int> recipeB;

    [ButtonMethod]
    public void TestForRecipe()
    {
        if (RecipeDatabase.Instance.CanCombine(recipeA, recipeB) == true)
        {
            Debug.Log("Recipe Exist");
        }
        else
        {
            Debug.Log("recipe Does Not Exist");
        }
    }
}
