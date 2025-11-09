using UnityEngine;

public class Billboarding : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.forward = mainCamera.transform.forward;
        //transform.rotation = mainCamera.transform.rotation;
        //transform.LookAt(mainCamera.transform);
    }
}
