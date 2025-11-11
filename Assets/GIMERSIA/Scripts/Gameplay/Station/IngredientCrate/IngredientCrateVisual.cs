using UnityEngine;

public class IngredientCrateVisual : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private IngredientCrate ingredientCrate;
    [SerializeField] private Animator animator;

    private void Start()
    {
        ingredientCrate.onCrateInteract.AddListener(IngredientCrate_OnCrateInteract);
    }

    public void IngredientCrate_OnCrateInteract()
    {
        animator.SetTrigger("OpenChest");
    }
}
