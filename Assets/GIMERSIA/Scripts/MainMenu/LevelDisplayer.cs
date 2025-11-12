using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayer : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private LevelVisualData levelVisualData;
    [SerializeField] private float score;

    [Header("Reference")]
    [SerializeField] private TMP_Text levelTitle;
    [SerializeField] private TMP_Text levelChapter;
    [SerializeField] private TMP_Text firstStarScoreNeeded;
    [SerializeField] private TMP_Text secondStarScoreNeeded;
    [SerializeField] private TMP_Text thirdStarScoreNeeded;
    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;
    [SerializeField] private Image levelImage;
    [SerializeField] private GameObject nextButtonObject;
    [SerializeField] private GameObject prevButtonObject;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private Button playButton;
    public void VisualizeLevel(int level)
    {
        SaveObject_LevelInformation levelInformation = SaveSystem.LoadObject<SaveObject_LevelInformation>(GameManager.Instance.LevelFileLocation,level);
        if(levelInformation == null )
        {
            score = 0f;
        }
        else
        {
            score = levelInformation.score;
        }
        LevelVisual levelVisual = levelVisualData.levelVisualList.Find(x => x.level == level);
        levelTitle.text = levelVisual.levelTitle;
        levelChapter.text = levelVisual.levelChapter;
        firstStarScoreNeeded.text = levelVisual.scoreNeededForStar1.ToString("F0");
        secondStarScoreNeeded.text = levelVisual.scoreNeededForStar2.ToString("F0");
        thirdStarScoreNeeded.text = levelVisual.scoreNeededForStar3.ToString("F0");
        firstStar.SetActive(score >= levelVisual.scoreNeededForStar1);
        secondStar.SetActive(score >= levelVisual.scoreNeededForStar2);
        thirdStar.SetActive(score >= levelVisual.scoreNeededForStar3);
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
