using UnityEngine;

public class ChefVisual : MonoBehaviour
{
    [Header("Static Data")]
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private ChefController chefController;
    void Start()
    {
        chefController.onChefMove.AddListener(ChefController_OnChefMove);
        chefController.onChefStop.AddListener(ChefController_OnChefStop);
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
