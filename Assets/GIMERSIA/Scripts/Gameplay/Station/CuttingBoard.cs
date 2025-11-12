using UnityEngine;
using System.Collections;
using Unity.Android.Gradle.Manifest;

public class CuttingBoard : MonoBehaviour, IInteractable, ITaskSource
{
    [Header("Static Data")]
    [SerializeField] private float chopBaseTime;
    [SerializeField] private int activityID;

    [Header("Dynamic Data")]
    [SerializeField] IHoldable currentItem;
    [SerializeField] bool isOccupied;
    [Header("Reference")]
    [SerializeField] Transform itemParent;
    [SerializeField] Transform interactionPoint;

    public Vector3 GetInteractionPoint() => interactionPoint.position;
    public Sprite GetIcon() => GameplayManager.Instance.GetChefActivitiesData.chefActivityList[GameplayManager.Instance.GetChefActivitiesData.chefActivityList.FindIndex(x => x.id == activityID)].activityIcon;
    public IInteractable GetInteractable() => this;
    public bool IsOccupied() => isOccupied;

    public IEnumerator OnInteract(ChefController chef)
    {
        Debug.Log("Start Interacting");
        
        if(currentItem == null && chef.IsHoldingItem)
        {
            IHoldable item = chef.GetHeldItem;
            if (item is IChopable)
            {
                PlaceItem(item, chef);
            }
        }
        else if (currentItem != null && currentItem is IChopable chopable && !chef.IsHoldingItem)
        {
            yield return StartCoroutine(ChopRoutine(chopable, chef));
        }
        else if(currentItem != null && currentItem is not IChopable && !chef.IsHoldingItem)
        {
            GiveItem(currentItem, chef);
        }

        Debug.Log("Stop Interacting");
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

    private IEnumerator ChopRoutine(IChopable chopable,ChefController chef)
    {
        isOccupied = true;
        float chopProgress = 0f;
        float lastChopSound = 0f;

        while (chopProgress < chopBaseTime)
        {
            chopProgress += Time.deltaTime;
            if(chopProgress > lastChopSound)
            {
                lastChopSound += 0.3f;
                AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.cuttingBoard);
            }
            yield return null;
        }

        // Finished chopping
        var choppedVersion = chopable.GetChoppedVersion();
        ReplaceItem(choppedVersion);

        isOccupied = false;
        yield return null;
    }

    private void ReplaceItem(IHoldable newItem)
    {
        Destroy(currentItem.GetGO());

        currentItem = newItem;
        newItem.GetGO().transform.SetParent(itemParent);
        newItem.GetGO().transform.localPosition = Vector3.zero;
    }
}

