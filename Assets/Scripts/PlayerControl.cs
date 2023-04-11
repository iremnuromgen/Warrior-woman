using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Control
{
    Vector3 velocity;
    [SerializeField]
    private float jumpForce;
    
    void Start()
    {
        facingRight = true;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Approximately(rigid.velocity.y, 0)) //getkeydown 1 kere basıldığında çalışır
        {
           rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
           anim.SetBool("Jump", true); //zıplama animasyonu
        }

        if(anim.GetBool("Jump") && Mathf.Approximately(rigid.velocity.y, 0)) //zıpladıktan sonra yere değince
        {
            anim.SetBool("Jump", false);
        }

    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);
        Flip(horizontal);
    }

    void Movement(float horizontal)
    {
        rigid.velocity = new Vector2(horizontal*speed,rigid.velocity.y);
        anim.SetFloat("speed",Mathf.Abs(horizontal));
    }

    void Flip(float horizontal)
    {
        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
        }
    }

}
