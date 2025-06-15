using UnityEngine;

public class ariaLadder  : MonoBehaviour
{   
    private float speed = 6f;
    private bool isClimbing;
    private bool isLadder;
    private float vertical;

    [SerializeField] Rigidbody2D rb;

    void Update()
    {
        if(isLadder){
            if(Input.GetKey(KeyCode.UpArrow)){
                vertical = 1f;
            }else if(Input.GetKey(KeyCode.DownArrow)){
                vertical = -1f;
            }else{
                vertical = 0f;
            }

            isClimbing = vertical != 0f;
        }
    }

    void FixedUpdate()
    {
        if(isClimbing){
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, vertical * speed);
        }else{
            rb.gravityScale = 1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder")){
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }
}
