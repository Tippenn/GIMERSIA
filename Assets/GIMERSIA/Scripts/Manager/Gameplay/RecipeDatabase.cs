using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeDatabase : Singleton<RecipeDatabase>
{
    [Header("Static Data")]
    [SerializeField] private ItemInformationDatabase itemDatabase;

    public bool CanCombine(IRecipe recipeA, IRecipe recipeB)
    {
        List<int> combinedRecipe = recipeA.GetIngredientID().Concat(recipeB.GetIngredientID()).ToList();
        foreach(ItemInformation item in itemDatabase.itemData)
        {
            if (HaveSameElements(combinedRecipe, item.ingredientID))
                return true;
        }
        return false;
    }   

    public bool CanCombine(List<int> recipeA, List<int> recipeB)
    {
        List<int> combinedRecipe = recipeA.Concat(recipeB).ToList();
        foreach (ItemInformation item in itemDatabase.itemData)
        {
            if (HaveSameElements(combinedRecipe, item.ingredientID))
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
        foreach (ItemInformation item in itemDatabase.itemData)
        {
            if (HaveSameElements(combinedRecipe, item.ingredientID))
            {
                GameObject gameObject = Instantiate(item.itemPrefab);
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
