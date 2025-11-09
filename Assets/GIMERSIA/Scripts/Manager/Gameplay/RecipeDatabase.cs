using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeDatabase : Singleton<RecipeDatabase>
{
    [Header("Static Data")]
    [SerializeField] private RecipeData recipeData;

    public bool CanCombine(IRecipe recipeA, IRecipe recipeB)
    {
        List<int> combinedRecipe = recipeA.GetIngredientID().Concat(recipeB.GetIngredientID()).ToList();
        foreach(RecipeInformation recipe in recipeData.recipeList)
        {
            if (HaveSameElements(combinedRecipe, recipe.recipeIDList))
                return true;
        }
        return false;
    }   

    public bool CanCombine(List<int> recipeA, List<int> recipeB)
    {
        List<int> combinedRecipe = recipeA.Concat(recipeB).ToList();
        foreach (RecipeInformation recipe in recipeData.recipeList)
        {
            if (HaveSameElements(combinedRecipe, recipe.recipeIDList))
                return true;
        }
        return false;
    }

    public IHoldable Combine(IRecipe recipeA, IRecipe recipeB)
    {
        List<int> combinedRecipe = recipeA.GetIngredientID().Concat(recipeB.GetIngredientID()).ToList();
        IHoldable itemA = recipeA as IHoldable;
        IHoldable itemB = recipeB as IHoldable;
        IHoldable combineItem;
        foreach (RecipeInformation recipe in recipeData.recipeList)
        {
            if (HaveSameElements(combinedRecipe, recipe.recipeIDList))
            {
                GameObject gameObject = Instantiate(recipe.recipePrefab);
                Destroy(itemA.GetGO());
                Destroy(itemB.GetGO());
                combineItem = gameObject.GetComponent<IHoldable>();
                return combineItem;
            }
        }
        return null;
    }

    private bool HaveSameElements(List<int> listA, List<int> listB)
    {
        if (listA.Count != listB.Count)
            return false;

        // Sort both and compare element by element
        listA.Sort();
        listB.Sort();

        for (int i = 0; i < listA.Count; i++)
        {
            if (listA[i] != listB[i])
                return false;
        }

        return true;
    }
}
