using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayer : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private LevelVisualData levelVisualData;

    [Header("Reference")]
    [SerializeField] private TMP_Text levelTitle;
    [SerializeField] private TMP_Text levelChapter;
    [SerializeField] private TMP_Text firstStarScoreNeeded;
    [SerializeField] private TMP_Text secondStarScoreNeeded;
    [SerializeField] private TMP_Text thirdStarScoreNeeded;
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
        levelChapter.text = levelVisual.levelChapter;
        firstStarScoreNeeded.text = levelVisual.scoreNeededForStar1.ToString("F0");
        secondStarScoreNeeded.text = levelVisual.scoreNeededForStar2.ToString("F0");
        thirdStarScoreNeeded.text = levelVisual.scoreNeededForStar3.ToString("F0");
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
