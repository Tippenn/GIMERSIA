using UnityEngine;

public class WholeLettuce : MonoBehaviour, IHoldable, IChopable
{
    [Header("Static Data")]
    [SerializeField] private GameObject choppedVersion;
    public GameObject GetGO() => gameObject;
    public IHoldable GetChoppedVersion()
    {
        GameObject newObj = Instantiate(choppedVersion);
        return newObj.GetComponent<IHoldable>();
    }
}

