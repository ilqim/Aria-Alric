using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
    }

    public void DamageEnemy()
    {
        Vector3 attackPosition = attackPoint.position;
        if (spriteRenderer != null)
        {
            if (spriteRenderer.flipX)
            {
                attackPosition.x = transform.position.x - attackRange;
            }
            else
            {
                attackPosition.x = transform.position.x + attackRange;
            }

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition, attackRange, enemyLayers);
            foreach (Collider2D hitEnemy in hitEnemies)
            {
                hitEnemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null || spriteRenderer == null)
            return;

        Vector3 attackPosition = attackPoint.position;
        if (spriteRenderer.flipX)
        {
            attackPosition.x = transform.position.x - attackRange;
        }
        else
        {
            attackPosition.x = transform.position.x + attackRange;
        }

        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}
