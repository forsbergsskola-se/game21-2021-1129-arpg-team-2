using UnityEngine;

public class DarkenScreen : MonoBehaviour
{
    [SerializeField] private float distanceFromCamera;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnPlayerDefeated()
    {
        transform.position = cam.transform.position + cam.transform.forward * distanceFromCamera;
    }

    public void OnPlayerNotDefeated()
    {
        // move the object outside camera view
    }
}
