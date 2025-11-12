using UnityEngine;
using System.Collections;

public class PlateStation : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Static Data")]
    [SerializeField] private GameObject platePrefab;
    [SerializeField] private int activityID;

    [Header("Dynamic Data")]
    [SerializeField] bool isOccupied;

    [Header("Reference")]
    [SerializeField] Transform interactionPoint;
    [SerializeField] Sprite icon;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => GameplayManager.Instance.GetChefActivitiesData.chefActivityList[GameplayManager.Instance.GetChefActivitiesData.chefActivityList.FindIndex(x => x.id == activityID)].activityIcon;
    public IInteractable GetInteractable() => this;

    public bool IsOccupied() => isOccupied;

    public IEnumerator OnInteract(ChefController chef)
    {
        if (chef.IsHoldingItem)
        {
            AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.warning);
        }
        else
        {
            GameObject prefab = Instantiate(platePrefab);
            Debug.Log("Is Interacting");
            chef.HoldItem(prefab);
        }
        yield return null;
    }
}
