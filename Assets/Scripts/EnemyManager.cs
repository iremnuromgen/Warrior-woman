using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Control
{
    public float health;
    public float damage;

    public int maxHealth=100;
    int currentHealth;


    
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -=damage;
        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("Hurt");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,2f);
    }

    private void OnTriggerEnter2D(Collider2D otcol)
    {
        otcol.GetComponent<PlayerManager>().getDamage(damage);
    }


}
