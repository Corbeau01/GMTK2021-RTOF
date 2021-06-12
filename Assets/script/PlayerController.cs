using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool IsActivated = false;
    int JumpPower = 4000;
    int speed = 150;
    float maxSpeed = 6f;
    Rigidbody2D body;
    bool canJump;

    int animState; 
    // 0 = idle, 1 = walking, 2 = running, 3 = jump, 4 = fall, 5 = landing, 6 = collide 

    Animator anim; 

    void Start() {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>(); 
    }

    void Update()
    {

        if(body.IsTouchingLayers( LayerMask.GetMask("Default"))) { 
            //body.mass = 100f;
            canJump = true;
            } else {
            //body.mass = 20f;
            canJump = false;
            }
          
        if (!IsActivated)
        {   
            body.mass = 50f;
            return;
        } else {
            body.mass = 1f;
        }
        

        if(Input.GetKeyDown(KeyCode.W) && canJump) //Input.GetKeyDown(KeyCode.Space)|| 
        {
            //this.GetComponent<Animator>().SetInteger("State", 1);
            body.AddForce(transform.up*JumpPower);
        }

        // walk
        if(body.velocity.x > 0.1 || body.velocity.x < -0.1)
        {
            animState = 1; 
        } 
        else
        {
            animState = 0; 
        }
        // run
        if(body.velocity.x > (maxSpeed / 2) || body.velocity.x < -(maxSpeed / 2))
        {
            animState = 2; 
        }

        anim.SetInteger("state", animState);

        if (body.velocity.x > maxSpeed || body.velocity.x < -(maxSpeed) ) {
            //if past max speed, decelerate.
            return;
        }

        if (Input.GetKey(KeyCode.A)) // && body.velocity.x < maxSpeed
        {
            body.AddForce(transform.right*-1 * speed);
            anim.SetBool("walking", true); 
        }
        if (Input.GetKey(KeyCode.D)) // && body.velocity.x > -(maxSpeed)
        {
            body.AddForce(transform.right * speed);
        }


        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.layer==22)//22 player1 //23player2
        {
            if(collision.gameObject.layer==20)//20 = player 1wall //21player2 wall
            {
                //colle
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        if (this.gameObject.layer == 22)//22 player1 //23player2
        {
            if (collision.gameObject.layer == 20)//20 = player 1wall //21player2 wall
            {
                //colle
            }
        }
    }
}
