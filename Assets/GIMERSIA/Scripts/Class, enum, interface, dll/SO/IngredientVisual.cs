using UnityEngine;

[CreateAssetMenu(fileName = "IngredientVisual", menuName = "Scriptable Objects/IngredientVisual")]
public class IngredientVisual : ScriptableObject
{
    public string ingredientName;
    public int ingredientID;
    public Sprite ingredientSprite;
}
