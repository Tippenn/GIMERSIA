using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("Static Data")]
    [SerializeField] private LevelVisualData levelVisualData;
    [SerializeField] private LevelVisual levelVisual;
    [SerializeField] private float waitTime;

    [Header("Dynamic Data")]
    [SerializeField] private bool isWinning;
    [Header("Reference")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text firstStarText;
    [SerializeField] private TMP_Text secondStarText;
    [SerializeField] private TMP_Text thirdStarText;
    [SerializeField] private GameObject firstStarImage;
    [SerializeField] private GameObject secondStarImage;
    [SerializeField] private GameObject thirdStarImage;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    private void Start()
    {
        levelVisual = levelVisualData.levelVisualList[levelVisualData.levelVisualList.FindIndex(x => x.level == GameManager.Instance.CurrentLevelPlayed)];
    }

    public void OnGameEnd_InitiateGameOver()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.peluit);
        AudioManager.Instance.PauseBGM();
        SaveObject_LevelInformation levelInformation = SaveSystem.LoadObject<SaveObject_LevelInformation>(GameManager.Instance.LevelFileLocation, GameManager.Instance.CurrentLevelPlayed);
        if(levelInformation != null )
        {
           levelInformation.score = Mathf.Max(levelInformation.score, GameplayManager.Instance.CurrentScore);
        }
        else
        {
            levelInformation = new SaveObject_LevelInformation();
            levelInformation.score = GameplayManager.Instance.CurrentScore;
        }
        SaveSystem.SaveObject(GameManager.Instance.LevelFileLocation, levelInformation, GameManager.Instance.CurrentLevelPlayed);
        
        if(GameplayManager.Instance.CurrentScore > levelVisual.scoreNeededForStar1)
        {
            isWinning = true;
            SaveObject_GameContext gameContext = SaveSystem.LoadObject<SaveObject_GameContext>(GameManager.Instance.GameContextLocation);
            if (gameContext != null)
            {
                if (gameContext.UnlockedLevel > GameManager.Instance.CurrentLevelPlayed)
                {

                }
                else
                {
                    gameContext.UnlockedLevel = GameManager.Instance.CurrentLevelPlayed + 1;
                    SaveSystem.SaveObject(GameManager.Instance.GameContextLocation, gameContext);
                }
            }
            else
            {
                gameContext.UnlockedLevel = GameManager.Instance.CurrentLevelPlayed + 1;
                SaveSystem.SaveObject(GameManager.Instance.GameContextLocation, gameContext);
            }
        }
        else
        {
            isWinning = false;
        }


        StartCoroutine(ProcessScore());
        OnScoreDoneProcessing();
    }

    public IEnumerator ProcessScore()
    {
        yield return new WaitForSeconds(waitTime);
        AudioManager.Instance.UnPauseBGM();
        gameOverPanel.SetActive(true);
        if(isWinning)
        {
            AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.win);
        }
        else
        {
            AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.lose);
        }
        firstStarText.text = levelVisual.scoreNeededForStar1.ToString("F0");
        secondStarText.text = levelVisual.scoreNeededForStar2.ToString("F0");
        thirdStarText.text = levelVisual.scoreNeededForStar3.ToString("F0");
        float score = GameplayManager.Instance.CurrentScore;
        currentScoreText.text = "Score : " + score.ToString("F0");
        firstStarImage.SetActive(score > levelVisual.scoreNeededForStar1);
        secondStarImage.SetActive(score > levelVisual.scoreNeededForStar2);
        thirdStarImage.SetActive(score > levelVisual.scoreNeededForStar3);
    }

    public void OnScoreDoneProcessing()
    {
        restartButton.interactable = true;
        nextLevelButton.interactable = true;
    }

    public void Button_Restart()
    {
        GameManager.Instance.ChangeScene("SceneLevel" + GameManager.Instance.CurrentLevelPlayed);
    }

    public void Button_MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenuScene");
    }
}
