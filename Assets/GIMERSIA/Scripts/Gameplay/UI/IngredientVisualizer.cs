using UnityEngine;
using UnityEngine.UI;

public class IngredientVisualizer : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Image ingredientImage;

    public Image IngredientImage => ingredientImage;

}
