using MyBox;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    public float score;

    [ButtonMethod]
    public void AddScore()
    {
        GameplayManager.Instance.AddScore(score);
    }
}
