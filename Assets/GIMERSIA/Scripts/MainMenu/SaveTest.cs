using MyBox;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    [Header("LevelContext")]
    public float score;
    public int currentLevel;

    [Header("GameContext")]
    public int unlockedLevel;

    [ButtonMethod]
    public void SetLevelContext()
    {
        SaveObject_LevelInformation levelInformation = new SaveObject_LevelInformation();
        levelInformation.score = score;
        SaveSystem.SaveObject(GameManager.Instance.LevelFileLocation,levelInformation,currentLevel);
    }

    [ButtonMethod]
    public void SetGameContext()
    {
        SaveObject_GameContext gameContext = new SaveObject_GameContext();
        gameContext.UnlockedLevel = unlockedLevel;
        SaveSystem.SaveObject(GameManager.Instance.GameContextLocation, gameContext);
    }
}
