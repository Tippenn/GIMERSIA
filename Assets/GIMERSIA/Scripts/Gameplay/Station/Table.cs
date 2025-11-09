using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Dynamic Data")]
    [SerializeField] IHoldable currentItem;
    [SerializeField] bool isOccupied;
    [Header("Reference")]
    [SerializeField] Transform itemParent;
    [SerializeField] Transform interactionPoint;
    [SerializeField] Sprite icon;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => icon;
    public IInteractable GetInteractable() => this;
    public bool IsOccupied() => isOccupied;

    public IEnumerator OnInteract(ChefController chef)
    {
        Debug.Log("Start Interacting");
        IHoldable item = chef.GetHeldItem;
        if (currentItem == null && chef.IsHoldingItem)
        {
            PlaceItem(item, chef);
        }
        else if (currentItem != null && !chef.IsHoldingItem)
        {
            GiveItem(currentItem, chef);
        }
        else if(currentItem != null && chef.IsHoldingItem)
        {
            IRecipe recipeA = currentItem as IRecipe;
            IRecipe recipeB = chef.GetHeldItem as IRecipe;
            if(RecipeDatabase.Instance.CanCombine(recipeA, recipeB))
            {
                IHoldable holdable = RecipeDatabase.Instance.Combine(recipeA, recipeB);
                PlaceItem(holdable, chef);
            }
            else
            {
                SwapItem(currentItem, item, chef);
            }
            
        }

        yield return null;
    }

    private void PlaceItem(IHoldable holdable, ChefController chef)
    {
        chef.DropItem();
        currentItem = holdable;
        currentItem.GetGO().transform.SetParent(itemParent);
        currentItem.GetGO().transform.localPosition = Vector3.zero;
    }

    private void GiveItem(IHoldable holdable, ChefController chef)
    {
        chef.HoldItem(holdable.GetGO());
        currentItem = null;
    }

    private void SwapItem(IHoldable tableItem, IHoldable chefItem, ChefController chef)
    {
        //kasi chef
        chef.HoldItem(tableItem.GetGO());

        //kasi table
        currentItem = chefItem;
        currentItem.GetGO().transform.SetParent(itemParent);
        currentItem.GetGO().transform.localPosition = Vector3.zero;
    }
}
