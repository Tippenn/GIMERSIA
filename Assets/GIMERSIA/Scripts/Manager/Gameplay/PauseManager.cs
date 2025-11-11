using UnityEngine;

public class PauseManager : PersistentSingleton<PauseManager>
{
    [Header("Static Data")]
    [Header("Dynamic Data")]
    [SerializeField] private bool isPaused;

    [Header("Reference")]
    [SerializeField] private GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PerformPause();
        }
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
}
