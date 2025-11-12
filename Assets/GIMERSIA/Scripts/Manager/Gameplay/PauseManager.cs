using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    [Header("Static Data")]
    [Header("Dynamic Data")]
    [SerializeField] private bool isiInit;
    [SerializeField] private bool isPaused;

    [Header("Reference")]
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (!isiInit) return;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PerformPause();
        }
    }

    public void Initialize(GameplayManager gameplayManager)
    {
        isiInit = true;
    }

    public void PerformPause()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void Button_Resume()
    {
        PerformPause();
    }

    public void Button_MainMenu()
    {
        GameManager.Instance.ChangeScene("MainMenuScene");
    }
}
