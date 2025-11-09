using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ChefController : MonoBehaviour, IInteractor, ITaskReceiver
{
    [Header("Static Data")]
    [Header("Dynamic Data")]
    private Queue<ChefTask> taskQueue = new Queue<ChefTask>();
    private IHoldable heldItem;
    private bool isBusy = false;

    [Header("Reference")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform holdingTransform;
    [SerializeField] private Transform heldItemParent;

    [Header("Event")]
    public UnityEvent<ChefTask> OnQueueUpdated;
    public UnityEvent OnQueueEmpty;

    public IHoldable GetHeldItem => heldItem;
    public bool IsHoldingItem => heldItem != null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void AddTask(ChefTask task)
    {
        taskQueue.Enqueue(task);
        OnQueueUpdated?.Invoke(task);
        if (!isBusy)
            StartCoroutine(ProcessNextTask());
    }

    private IEnumerator ProcessNextTask()
    {
        while (taskQueue.Count > 0)
        {
            isBusy = true;
            ChefTask current = taskQueue.Dequeue();
            OnQueueUpdated?.Invoke(current); // update UI

            // Move to target
            Vector3 dest = current.Target.GetInteractionPoint();
            agent.SetDestination(dest);

            while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                yield return null;

            yield return current.Target.OnInteract(this);
        }

        isBusy = false;
        OnQueueEmpty?.Invoke(); // empty
    }

    public void HoldItem(GameObject itemGO)
    {
        IHoldable holdable = itemGO.GetComponent<IHoldable>();
        itemGO.transform.SetParent(heldItemParent);
        itemGO.transform.localPosition = Vector3.zero;
        heldItem = holdable;
    }

    public void DropItem()
    {
        heldItem = null;
    }
}
