using UnityEngine;
using System.Collections;
public class ServingStation : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Dynamic Data")]
    [SerializeField] bool isOccupied;
    [Header("Reference")]
    [SerializeField] Transform interactionPoint;
    [SerializeField] Sprite icon;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => icon;
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
    }
}
