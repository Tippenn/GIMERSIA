using UnityEngine;
using UnityEngine.UI;

public class ChefVisual : MonoBehaviour
{
    [Header("Static Data")]
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private ChefController chefController;
    [SerializeField] private GameObject taskCanvas;
    [SerializeField] private Image taskImage;
    void Start()
    {
        taskCanvas.SetActive(false);
        chefController.onChefMove.AddListener(ChefController_OnChefMove);
        chefController.onChefStop.AddListener(ChefController_OnChefStop);
        chefController.OnQueueWorkOn.AddListener(OnQueueWorkOn_UpdateTaskImage);
        chefController.OnQueueEmpty.AddListener(OnQueueEmpty_UpdateTaskCanvas);
    }

    public void OnQueueWorkOn_UpdateTaskImage(ChefTask task)
    {
        taskCanvas.SetActive(true);
        taskImage.sprite = task.Icon;
    }

    public void OnQueueEmpty_UpdateTaskCanvas()
    {
        taskCanvas.SetActive(false);
    }

    public void ChefController_OnChefMove()
    {
        animator.SetBool("isMoving", true);
    }

    public void ChefController_OnChefStop()
    {
        animator.SetBool("isMoving", false);
    }
}
