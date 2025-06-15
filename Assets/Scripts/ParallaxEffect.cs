using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxMultiplier = 0.5f;
    public float minYPosition = 0f;
    public float maxYPosition = 5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;

        transform.position += new Vector3(deltaX * parallaxMultiplier, 0, 0);

        float targetY = cameraTransform.position.y;
        targetY = Mathf.Clamp(targetY, minYPosition, maxYPosition);

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

        lastCameraPosition = cameraTransform.position;
    }
}
