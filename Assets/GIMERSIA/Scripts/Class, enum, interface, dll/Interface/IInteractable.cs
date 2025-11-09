using System.Collections;
using UnityEngine;

public interface IInteractable
{
    Vector3 GetInteractionPoint();
    IEnumerator OnInteract(ChefController chef);
    public bool IsOccupied();
}
