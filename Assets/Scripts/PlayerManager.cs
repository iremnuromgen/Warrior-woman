using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Control
{
    public float health;
    public bool dead = false;

    PlayerCombat playercombat;
    
    public Image healthBar;
    public float initHealth;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        playercombat = GetComponent<PlayerCombat>();
        initHealth = health;
        
    }

    
    void Update()
    {
        CharacterAttack();
        healthBar.fillAmount = health / initHealth;
    }

    public void getDamage(float damage)
    {
        if(health - damage >= 0)
        {
            health -= damage;
            anim.SetTrigger("isHurt");
        }
        else
        {
            health = 0;
            Die();
        }
        amIdead();

    }

    void amIdead()
    {
        if(health == 0)
        {
            dead = true;
        }
    }

    void CharacterAttack()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("isAttack");
            playercombat.DamageEnemy();
        }
    }

    void Die()
    {
        anim.SetBool("isDead",true);
        GetComponent<PlayerControl>().enabled = false;
        Destroy(gameObject,2f);
    }

}
