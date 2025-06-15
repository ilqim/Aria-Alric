using UnityEngine;

public class PlatformControllerHorizontal : MonoBehaviour
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
        openPosition = closedPosition + new Vector3(openHeight, 0, 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
