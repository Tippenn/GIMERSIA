using UnityEngine;

[CreateAssetMenu(fileName = "LevelVisual", menuName = "Scriptable Objects/LevelVisual")]
public class LevelVisual : ScriptableObject
{
    public int level;
    public string levelTitle;
    public string levelChapter;
    public float scoreNeededForStar1;
    public float scoreNeededForStar2;
    public float scoreNeededForStar3;
    public Sprite levelSprite;
}
