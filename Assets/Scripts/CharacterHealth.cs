using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private bool enemyAttack;
    private float enemyTimer;

    private MonoBehaviour playerController;
    void Start()
    {
        currentHealth = maxHealth;
        enemyTimer = 3f;
        healthBar.SetMaxHealth(maxHealth);

        if (GetComponent<alricKontrolAttack>() != null)
        {
            playerController = GetComponent<alricKontrolAttack>();
        }
        else if (GetComponent<ariaKontrolAttack>() != null)
        {
            playerController = GetComponent<ariaKontrolAttack>();
        }
    }

    void Update()
    {
        EnemyAttackSpacing();
    }

    void EnemyAttackSpacing()
    {
        if (!enemyAttack)
        {
            enemyTimer -= Time.deltaTime;
        }

        if (enemyTimer <= 0f)
        {
            enemyAttack = true;
            enemyTimer = 3f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (enemyAttack)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthBar.SetHealth(currentHealth);
            enemyAttack = false;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (playerController != null)
        {
            if (playerController is alricKontrolAttack ilkim)
            {
                currentHealth = 0;
                healthBar.SetHealth(currentHealth);
                ilkim.Die();
            }
            else if (playerController is ariaKontrolAttack rabia)
            {
                currentHealth = 0;
                healthBar.SetHealth(currentHealth);
                rabia.Die();
            }
        }
    }
}
