using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform EnemyAttackPoint;
    public LayerMask PlayerLayers;

    public float EnemyAttackRange = 0.5f;
    public int EnemyAttackDamage = 40;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
    }

    public void DamagePlayer()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(EnemyAttackPoint.position, EnemyAttackRange, PlayerLayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<CharacterHealth>().TakeDamage(EnemyAttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(EnemyAttackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(EnemyAttackPoint.position , EnemyAttackRange);
    }
}
