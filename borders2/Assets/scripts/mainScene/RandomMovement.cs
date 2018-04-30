using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public Rigidbody2D rb2D;
    public Vector2 direction;
    public float speed = 4f;   

    int[] directionArray;
    bool timeExplicited = true;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        directionArray = new int[] { -1, 1 }; 
        direction = new Vector2(directionArray[Random.Range(0, 2)], directionArray[Random.Range(0,2)]);   //Initialize Random Direction  
        InvokeRepeating("ChangeDirection", Random.Range(2f,3.5f),1f);
    }


    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position+direction*Time.fixedDeltaTime*speed);
                       
    }

    void ChangeDirection()
    {
        
        direction = new Vector2(directionArray[Random.Range(0, 2)], directionArray[Random.Range(0, 2)]);
    }


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timeExplicited)
        {
            direction *= -1;                 // Change direction when it hits the wall
            timeExplicited = false;          // Do not change direction for time in courutine   
            StartCoroutine("WaitForSecond");    
        }      
        
    }

    IEnumerator WaitForSecond()
    {
        timeExplicited = false;
        yield return new WaitForSeconds(0.6f);
        timeExplicited = true;

    }

}
