using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public GameObject parchament;
    private Camera mainCamera;

    public Canvas canvas;

    public PlatformControllerVertical platformController;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            parchament.SetActive(true);
            canvas.gameObject.SetActive(true);

            Vector3 newPosition = mainCamera.transform.position;
            newPosition.z = -3f;
            parchament.transform.position = newPosition;

            parchament.transform.rotation = mainCamera.transform.rotation;
        }
    }
}
