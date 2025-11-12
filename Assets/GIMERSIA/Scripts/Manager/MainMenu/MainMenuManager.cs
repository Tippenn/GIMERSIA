using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [Header("Static Data")]
    [SerializeField] private string gameplayScene;
    [SerializeField] private int unlockedLevel = 0;
    [Header("Dynamic Data")]
    [SerializeField] private int currentLevelSelected = 0;
    [Header("Reference")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private LevelDisplayer levelDisplayer;

    public int UnlockedLevel => unlockedLevel;
    protected override void Awake()
    {
        base.Awake();
        SaveObject_GameContext gameContext = SaveSystem.LoadObject<SaveObject_GameContext>(GameManager.Instance.GameContextLocation);
        if(gameContext != null)
        {
            unlockedLevel = gameContext.UnlockedLevel;
        }
        else
        {
            unlockedLevel = 0;
        }
        
    }

    private void Start()
    {
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.mainMenuBGM);
    }

    #region Button
    public void Button_PlayPanel_Play()
    {
        AudioManager.Instance.PauseBGM();   
        GameManager.Instance.CurrentLevelPlayed = currentLevelSelected;
        GameManager.Instance.ChangeScene(GameManager.Instance.GameplaySceneLocation + currentLevelSelected.ToString());
    }

    public void Button_PlayPanel_NextLevel()
    {
        currentLevelSelected++;
        levelDisplayer.VisualizeLevel(currentLevelSelected);
    }

    public void Button_PlayPanel_PreviousLevel()
    {
        currentLevelSelected--;
        levelDisplayer.VisualizeLevel(currentLevelSelected);
    }

    public void Button_SettingPanel_Close()
    {
        settingPanel.SetActive(false);
    }

    public void Button_MainPanel_Play()
    {
        playPanel.SetActive(true);
        levelDisplayer.VisualizeLevel(currentLevelSelected);
    }

    public void Button_MainPanel_Settings()
    {
        settingPanel.SetActive(true);
    }

    public void Button_MainPanel_Exit()
    {
        Application.Quit();
    }
    #endregion
}
