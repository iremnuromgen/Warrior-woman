using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl : Control
{
    [SerializeField]
    private Transform[] spots;

    private float waitTime;
    [SerializeField]
    private float startTime;
    void Start()
    {
        waitTime = startTime;
        facingRight = true;
    }

    
    void Update()
    {
        if(facingRight)
        {
            if(waitTime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position,spots[1].position,speed*Time.deltaTime);

                if(Vector2.Distance(transform.position,spots[1].position)<.5f)
                {
                    Flip();
                    waitTime = startTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
 
        }
        else
        {
            if(waitTime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position,spots[0].position,speed*Time.deltaTime);

                if(Vector2.Distance(transform.position,spots[0].position)<.5f)
                {
                    Flip();
                    waitTime = startTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
    }

     void Flip()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
        
    }
}
