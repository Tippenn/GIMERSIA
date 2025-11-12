using UnityEngine;
using System.Collections;
using Unity.Android.Gradle.Manifest;

public class ServingStation : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Static Data")]
    [SerializeField] private int activityID;

    [Header("Dynamic Data")]
    [SerializeField] bool isOccupied;

    [Header("Reference")]
    [SerializeField] private FoodOrderSystem foodOrderSystem;
    [SerializeField] Transform interactionPoint;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => GameplayManager.Instance.GetChefActivitiesData.chefActivityList[GameplayManager.Instance.GetChefActivitiesData.chefActivityList.FindIndex(x => x.id == activityID)].activityIcon;
    public IInteractable GetInteractable() => this;
    public bool IsOccupied() => isOccupied;

    public IEnumerator OnInteract(ChefController chef)
    {
        Debug.Log("Start Interacting");
        isOccupied = true;
        if (chef.IsHoldingItem)
        {
            IHoldable item = chef.GetHeldItem;
            PlaceItem(item, chef);
        }
        isOccupied = false;
        yield return null;
        
    }

    private void PlaceItem(IHoldable holdable, ChefController chef)
    {
        chef.DropItem();
        Destroy(holdable.GetGO());
        if(holdable is IRecipe recipe)
        {
            AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.bellOrder);
            FoodOrderSystem.Instance.GiveItem(recipe);
        }
        
    }
}
