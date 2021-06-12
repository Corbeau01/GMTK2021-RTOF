using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public bool IsActivated = false;
    public bool player1;

    int JumpPower = 6000;
    int acceleration = 150;
    float maxSpeed = 8f;
    Rigidbody2D body;
    bool canJump;
    bool gripWall;


    ContactPoint2D[] contacts = new ContactPoint2D[16];
    Vector2 groundNormal;

    void Start() {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(body.IsTouchingLayers( LayerMask.GetMask("PlayingField"))) { 
            //body.mass = 100f;
            canJump = true;
            gripWall = false;
            } else {
            //body.mass = 20f;
            canJump = false;
            gripWall = false;
        }

        if( (player1 && body.IsTouchingLayers(LayerMask.GetMask("Player1Interaction"))) || (!player1 && body.IsTouchingLayers(LayerMask.GetMask("Player1Interaction"))) ) { 
            gripWall = true;
            canJump = false;
        }




        if(gripWall) {
            findNormal();
        } else {
            groundNormal = new Vector2(0,1);
        }

        Debug.DrawLine(transform.position, transform.position+(Vector3)groundNormal);
        Debug.Log(groundNormal);
        body.AddForce(groundNormal * Physics2D.gravity[1]);



        if(!IsActivated)
        {   
            body.mass = 50f;
            return;
        } else {
            body.mass = 1f;
        }
        

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump) //Input.GetKeyDown(KeyCode.Space)|| 
        {
            //this.GetComponent<Animator>().SetInteger("State", 1);
            body.AddForce(groundNormal * JumpPower);
        }





        if(body.velocity.magnitude > maxSpeed) {return;}

        if (Input.GetKey(KeyCode.A)) // && body.velocity.x > -(maxSpeed) 
        {
            body.AddForce( rotate(groundNormal,90) * acceleration);
        }
        if (Input.GetKey(KeyCode.D)) // && body.velocity.x < maxSpeed
        {
            body.AddForce( rotate(groundNormal,270) * acceleration);
        }




        
    }


    private void findNormal() {

        body.GetContacts(contacts);
        Vector2 sum = Vector2.zero;
        int i = 0; //pour calculer moyenne

        foreach(ContactPoint2D contact in contacts) {
            if(contact.normal != Vector2.zero) {
                sum += contact.normal.normalized;
                i++;
            }
        }
        Array.Clear(contacts, 0, contacts.Length);

        groundNormal = (sum/i).normalized;    
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.layer==22)//22 player1 //23player2
        {
            if(collision.gameObject.layer==20)//20 = player 1wall //21player2 wall
            {
                //colle
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
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


    public static Vector2 rotate(Vector2 v, float angle) {
        float delta = angle * Mathf.Deg2Rad;
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }


}
