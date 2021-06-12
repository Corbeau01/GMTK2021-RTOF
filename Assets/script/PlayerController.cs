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

    void Start() {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(body.IsTouchingLayers( LayerMask.GetMask("PlayingField"))) { 
            //body.mass = 100f;
            canJump = true;
            } else {
            //body.mass = 20f;
            canJump = false;
            }


        if(!IsActivated)
        {   
            body.mass = 50f;
            return;
        } else {
            body.mass = 1f;
        }
        

        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space) && canJump) //Input.GetKeyDown(KeyCode.Space)|| 
        {
            //this.GetComponent<Animator>().SetInteger("State", 1);
            body.AddForce(transform.up*JumpPower);
        }




        if(body.velocity.x > maxSpeed || body.velocity.x < -(maxSpeed) ) {
            //if past max speed, decelerate.
            return;
        }

        if (Input.GetKey(KeyCode.A)) // && body.velocity.x < maxSpeed
        {
            body.AddForce(transform.right*-1 * speed);
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
