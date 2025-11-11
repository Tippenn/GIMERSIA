using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class IngredientCrate : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Static Data")]
    [SerializeField] private GameObject ingredientPrefab;
    [SerializeField] private int activityID;

    [Header("Dynamic Data")]
    [SerializeField] bool isOccupied;

    [Header("Reference")]
    [SerializeField] Transform interactionPoint;

    [Header("Event")]
    public UnityEvent onCrateInteract;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => GameplayManager.Instance.GetChefActivitiesData.chefActivityList[GameplayManager.Instance.GetChefActivitiesData.chefActivityList.FindIndex(x => x.id == activityID)].activityIcon;
    public IInteractable GetInteractable() => this;

    public bool IsOccupied() => isOccupied;

    public IEnumerator OnInteract(ChefController chef)
    {
        if (chef.IsHoldingItem)
        {

        }
        else
        {
            onCrateInteract?.Invoke();
            GameObject prefab = Instantiate(ingredientPrefab);
            Debug.Log("Is Interacting");
            chef.HoldItem(prefab);
        }
        yield return null;

    }
}