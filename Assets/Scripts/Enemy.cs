using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    private int currentHealth;
    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("isHurt");

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        anim.SetBool("isDead", true);

        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;

        yield return new WaitForSeconds(animationLength);

        yield return new WaitForSeconds(0.5f);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
