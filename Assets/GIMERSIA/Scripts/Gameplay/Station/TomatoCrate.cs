using UnityEngine;
using System.Collections;

public class TomatoCrate : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Static Data")]
    [SerializeField] private GameObject tomatoPrefab;

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
        GameObject prefab = Instantiate(tomatoPrefab);
        Debug.Log("Is Interacting");
        chef.HoldItem(prefab);
        yield return null;
    }
}
