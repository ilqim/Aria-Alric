using UnityEngine;

public class PlatformControllerVertical : MonoBehaviour
{
    public Transform platform;
    public float openHeight = 3f;
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private int activeButtons = 0;

    void Start()
    {
        closedPosition = platform.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    void Update()
    {
        if (activeButtons > 0)
        {
            platform.position = Vector3.MoveTowards(platform.position, openPosition, openSpeed * Time.deltaTime);
        }
        else
        {
            platform.position = Vector3.MoveTowards(platform.position, closedPosition, openSpeed * Time.deltaTime);
        }
    }

    public void ButtonActivated()
    {
        activeButtons++;
    }

    public void ButtonDeactivated()
    {
        activeButtons--;
        if (activeButtons < 0) activeButtons = 0;
    }
}
