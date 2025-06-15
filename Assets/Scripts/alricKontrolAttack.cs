using UnityEngine;

public class alricKontrolAttack : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer spriteR;

    private bool isGrounded = true;
    private bool jump;
    private bool isDead = false;
    private bool isAttacking = false;

    private float moveDirection;

    public float moveSpeed = 2f;
    public float jumpForce = 8f;

    public GameObject deathMenuCanvas;
    private PlayerCombat playerCombat;

    public HealthBar healthBar;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        playerCombat = GetComponent<PlayerCombat>();

        if (deathMenuCanvas != null)
            deathMenuCanvas.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isDead || isAttacking) return;

        body.linearVelocity = new Vector2(moveSpeed * moveDirection, body.linearVelocityY);

        if (jump)
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
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

    private void Attack()
    {
        if (isAttacking) return;

        isAttacking = true;
        anim.SetTrigger("isattack");
        Invoke("ResetAttack", 0.5f);
        playerCombat.DamageEnemy();
    }

    private void ResetAttack()
    {
        isAttacking = false;
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
            Die();
        }
    }

    public void Die()
    {

        if (isDead) return;
        isDead = true;
        anim.SetBool("isdead", true);
        healthBar.SetHealth(0);
        body.linearVelocity = Vector2.zero;
        body.bodyType = RigidbodyType2D.Static;

        Invoke("ShowDeathMenu", 2f);
    }

    private void ShowDeathMenu()
    {
        Time.timeScale = 0f;
        if (deathMenuCanvas != null)
            deathMenuCanvas.SetActive(true);
    }
}
