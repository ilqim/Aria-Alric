using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float distance;
    public float minDistance = 1f;
    public float maxFollowDistance = 5f;
    public float followspeed;

    private Transform target;
    private Animator anim;
    private Enemy enemyScript;
    private bool isFollowing = false;
    private bool isHurt = false;
    private float currentDirection = 1;
    private float enemytimer = 1.5f;

    EnemyCombat enemycombat;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        anim = GetComponent<Animator>();
        enemyScript = GetComponent<Enemy>();
        enemycombat = GetComponent<EnemyCombat>();
        
        FindClosestPlayer();
        
        if (target != null)
        {
            int direction = target.position.x > transform.position.x ? 1 : -1;
            FaceDirection(direction);
        }
    }

    void Update()
    {
        if (!isHurt && !enemyScript.isDead)
        {
            FindClosestPlayer();
            EnemyAi();
        }
    }

    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestTarget = player.transform;
            }
        }

        if (closestTarget != null)
        {
            target = closestTarget;
        }
    }

    void EnemyAi()
    {
        if (target == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        bool seesPlayer = false;

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, distance);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitRight.collider != null && hitRight.collider.CompareTag("Player"))
        {
            seesPlayer = true;
            if (!isFollowing) FaceDirection(1);
        }
        else if (hitLeft.collider != null && hitLeft.collider.CompareTag("Player"))
        {
            seesPlayer = true;
            if (!isFollowing) FaceDirection(-1);
        }

        if (seesPlayer && distanceToPlayer <= maxFollowDistance)
        {
            isFollowing = true;

            if (distanceToPlayer <= minDistance)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                enemycombat.DamagePlayer();
            }
            else
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
                EnemyFollow();
            }
        }
        else
        {
            isFollowing = false;
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
        }
    }

    void EnemyFollow()
    {
        if (!isFollowing || target == null) return;

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        float distanceToPlayer = Vector3.Distance(transform.position, targetPosition);

        int direction = targetPosition.x > transform.position.x ? 1 : -1;
        FaceDirection(direction);

        if (distanceToPlayer > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, followspeed * Time.deltaTime);
        }
    }

    void FaceDirection(int direction)
    {
        if (currentDirection != direction)
        {
            currentDirection = 0.5f * direction;
            transform.localScale = new Vector3(currentDirection, 0.5f, 0.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        isHurt = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        enemyScript.TakeDamage(damage);
        StartCoroutine(ResetHurtAnimation());
    }

    IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distance);
        Gizmos.DrawLine(transform.position, transform.position - transform.right * distance);
    }
}
