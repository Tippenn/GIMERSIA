using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayer : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private LevelVisualData levelVisualData;

    [Header("Reference")]
    [SerializeField] private TMP_Text levelTitle;
    [SerializeField] private Image levelImage;
    [SerializeField] private GameObject nextButtonObject;
    [SerializeField] private GameObject prevButtonObject;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button playButton;
    public void VisualizeLevel(int level)
    {
        LevelVisual levelVisual = levelVisualData.levelVisualList.Find(x => x.level == level);
        levelTitle.text = levelVisual.levelTitle;
        levelImage.sprite = levelVisual.levelSprite;
        if(level == MainMenuManager.Instance.UnlockedLevel)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        if(level == 0)
        {
            prevButton.interactable = false;
        }
        else
        {
            prevButton.interactable = true;
        }
    }
}
