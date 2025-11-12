using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    [Header("Static Data")]
    [SerializeField] private LevelVisualData levelVisualData;
    [SerializeField] private Animator animator;
    [SerializeField] private static readonly string gameContextLocation = "GameContext";
    [SerializeField] private static readonly string levelFileLocation = "LevelContext";
    [SerializeField] private static readonly string gameplaySceneLocation = "SceneLevel";
    [Header("Dynamic Data")]
    [SerializeField] private bool isChangingScene = false;
    [SerializeField] private int currentLevelPlayed;
    public string LevelFileLocation => levelFileLocation;
    public string GameContextLocation => gameContextLocation;
    public string GameplaySceneLocation => gameplaySceneLocation;
    public int CurrentLevelPlayed
    {
        get => currentLevelPlayed;
        set => currentLevelPlayed = value;
    }
    public LevelVisualData LevelVisualData => levelVisualData;

    protected override void Awake()
    {
        base.Awake();
    }

    //public void ChangeScene(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    Time.timeScale = 1.0f;
    //}
    public async void ChangeScene(string name)
    {
        if (isChangingScene)
        {
            return;
        }
        isChangingScene = true;
        float animLength;
        animator.SetTrigger("Exit");
        animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("Exit Length:" + animLength);
        await Task.Delay(Mathf.CeilToInt(animLength * 1000)); // convert sec -> ms

        await SceneManager.LoadSceneAsync(name);

        animator.SetTrigger("Enter");
        animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        await Task.Delay(Mathf.CeilToInt(animLength * 1000)); // convert sec -> ms
        Debug.Log("Enter Length:" + animLength);
        Time.timeScale = 1f;
        isChangingScene = false;
    }
}
