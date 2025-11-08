using UnityEngine;

[CreateAssetMenu(fileName = "LevelVisual", menuName = "Scriptable Objects/LevelVisual")]
public class LevelVisual : ScriptableObject
{
    public int level;
    public string levelTitle;
    public Sprite levelSprite;
}
