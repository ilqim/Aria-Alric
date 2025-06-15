using UnityEngine;

public class BoxControllerVertical : MonoBehaviour
{
    public Transform box;
    public float liftHeight = 3f;
    public float liftSpeed = 2f;

    private Vector3 initialPosition;
    private Vector3 liftedPosition;
    private Rigidbody2D rb;
    private bool isButtonPressed = false;

    void Start()
    {
        initialPosition = box.position;
        liftedPosition = initialPosition + new Vector3(0, liftHeight, 0);

        rb = box.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Kutuda Rigidbody2D bileşeni bulunamadı!");
        }
    }

    void Update()
    {
        if (isButtonPressed)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            box.position = Vector3.MoveTowards(box.position, liftedPosition, liftSpeed * Time.deltaTime);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void ButtonActivated()
    {
        isButtonPressed = true;
    }

    public void ButtonDeactivated()
    {
        isButtonPressed = false;
    }
}
