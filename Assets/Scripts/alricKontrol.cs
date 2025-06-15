using UnityEngine;

public class alricKontrol : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer spriteR;

    private bool isGrounded = true;
    private bool jump;

    private bool isDead = false;

    private float moveDirection;

    public float moveSpeed = 2f;
    public float jumpForce = 8f;

    public GameObject deathMenuCanvas;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        if (deathMenuCanvas != null)
            deathMenuCanvas.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isDead) return;

        body.linearVelocity = new Vector2(moveSpeed * moveDirection, body.linearVelocity.y);

        if (jump)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            jump = false;
        }
    }

    void Update()
    {
        if (isDead) 
        {
            moveDirection = 0f;
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            spriteR.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            spriteR.flipX = false;
        }
        else
        {
            moveDirection = 0f;
        }

        anim.SetFloat("speed", Mathf.Abs(moveDirection * moveSpeed));

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            isGrounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("isgrounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Button"))
        {
            isGrounded = true;
            anim.SetBool("isgrounded", true);
        }
        else if (collision.gameObject.CompareTag("DeathArea") && !isDead)
        {
            isDead = true;
            anim.SetBool("isdead", true);
            body.linearVelocity = Vector2.zero;
            body.bodyType = RigidbodyType2D.Static;

            Invoke("ShowDeathMenu", 2f);
        }
    }

    private void ShowDeathMenu()
    {
        Time.timeScale = 0f;
        if(deathMenuCanvas != null)
            deathMenuCanvas.SetActive(true);
    }
}
