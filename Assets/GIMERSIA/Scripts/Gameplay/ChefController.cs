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
    [SerializeField] private ChefTask currentTask;
    private IHoldable heldItem;
    private bool isBusy = false;

    [Header("Reference")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform holdingTransform;
    [SerializeField] private Transform heldItemParent;

    [Header("Event")]
    public UnityEvent OnQueueUpdated;
    public UnityEvent<ChefTask> OnQueueWorkOn;
    public UnityEvent OnQueueEmpty;
    public UnityEvent onChefMove;
    public UnityEvent onChefStop;

    public ChefController Chef => this;
    public Queue<ChefTask> TaskQueue => taskQueue;
    public ChefTask CurrentTask => currentTask;
    public IHoldable GetHeldItem => heldItem;
    public bool IsHoldingItem => heldItem != null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void AddTask(ChefTask task)
    {
        taskQueue.Enqueue(task);
        OnQueueUpdated?.Invoke();
        if (!isBusy)
            StartCoroutine(ProcessNextTask());
    }

    private IEnumerator ProcessNextTask()
    {
        while (taskQueue.Count > 0)
        {
            isBusy = true;
            currentTask = taskQueue.Dequeue();
            OnQueueUpdated?.Invoke(); // update UI
            OnQueueWorkOn?.Invoke(currentTask);

            // Move to target
            Vector3 dest = currentTask.Target.GetInteractionPoint();
            agent.SetDestination(dest);
            onChefMove?.Invoke();
            while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                yield return null;

            onChefStop?.Invoke();
            yield return currentTask.Target.OnInteract(this);
        }

        isBusy = false;
        OnQueueEmpty?.Invoke(); // empty
    }

    public void HoldItem(GameObject itemGO)
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.item);
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
