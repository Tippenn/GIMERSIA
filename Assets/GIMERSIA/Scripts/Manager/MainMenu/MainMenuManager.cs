using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [Header("Static Data")]
    [SerializeField] private string gameplayScene;
    [SerializeField] private string gameContextFileDirection;
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
        SaveSystem.LoadObject<SaveObject_GameContext>(gameContextFileDirection);
    }

    #region Button
    public void Button_PlayPanel_Play()
    {
        GameManager.Instance.ChangeScene(gameplayScene + currentLevelSelected.ToString());
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
