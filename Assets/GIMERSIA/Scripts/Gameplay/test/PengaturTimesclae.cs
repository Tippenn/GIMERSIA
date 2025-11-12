using UnityEngine;

public class PengaturTimesclae : MonoBehaviour
{
    public float timeScale;
    private void Start()
    {
        Time.timeScale = timeScale;
    }
}
