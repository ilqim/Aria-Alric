using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    private float vertical;
    private float speed = 6f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (isLadder)
        {
            vertical = Input.GetAxis("Vertical");
            isClimbing = vertical != 0f;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
