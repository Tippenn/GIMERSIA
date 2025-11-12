using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : Singleton<TutorialManager>
{

    [Header("Reference")]
    [SerializeField] private GameObject tutorialPanel;

    [Header("Event")]
    public UnityEvent onTutorialDone;

    public void Button_GotIt()
    {
        tutorialPanel.SetActive(false);
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.countdown);
        onTutorialDone?.Invoke();
    }

}
