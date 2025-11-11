using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropTaskSystem : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] GameObject dragIconPrefab;
    [SerializeField] LayerMask worldRaycastMask = ~0;

    [Header("Dynamic Data")]
    [SerializeField] private bool isInit;

    [Header("Reference")]
    [SerializeField] Canvas uiCanvas;
    

    private ITaskSource draggedSource;
    private GameObject dragIconInstance;
    private RectTransform dragIconRect;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Initialize(GameplayManager gameplayManager)
    {
        isInit = true;
    }

    void Update()
    {
        if (!isInit) return;

        // Start dragging
        if (Input.GetMouseButtonDown(0))
        {
            // ignore clicks over UI
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, worldRaycastMask))
            {
                if (hit.collider.TryGetComponent<ITaskSource>(out var taskSource))
                {
                    StartDrag(taskSource);
                }
            }
        }

        if (dragIconInstance != null)
        {
            Vector2 screenPos = Input.mousePosition;
            dragIconRect.position = screenPos;
        }

        // Drop
        if (Input.GetMouseButtonUp(0) && draggedSource != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, worldRaycastMask))
            {
                // Dropped on a ChefController (in world) ?
                if (hit.collider.TryGetComponent<ITaskReceiver>(out var chef))
                {
                    var task = new ChefTask(draggedSource.GetInteractable(), draggedSource.GetIcon());
                    chef.AddTask(task);
                }
                else
                {
                    // not dropped on chef -> cancel or return
                    Debug.Log("Cancel ygy");
                    // you can optionally drop the task back on a counter etc.
                }
            }

            EndDrag();
        }
    }
    private void StartDrag(ITaskSource source)
    {
        draggedSource = source;
        // create UI icon
        dragIconInstance = Instantiate(dragIconPrefab, uiCanvas.transform);
        dragIconRect = dragIconInstance.GetComponent<RectTransform>();
        var img = dragIconInstance.GetComponent<Image>();
        img.sprite = source.GetIcon();
        // optional scale / animation
        // highlight possible chefs
    }

    private void EndDrag()
    {
        draggedSource = null;
        if (dragIconInstance) Destroy(dragIconInstance);
        dragIconInstance = null;
    }

}

