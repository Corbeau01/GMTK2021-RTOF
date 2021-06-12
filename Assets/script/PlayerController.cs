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

            canJump = true;
            gripWall = false;
            } else {
            canJump = false; //faux
            gripWall = false;
        }


        if( player1 == true && body.IsTouchingLayers(LayerMask.GetMask("Player1Interaction"))) { 
            gripWall = true;
            canJump = true;
        }

        if( player1 == false && body.IsTouchingLayers(LayerMask.GetMask("Player2Interaction"))) { 
            gripWall = true;
            canJump = true;
        }




        if(gripWall) {
            findNormal();
            Debug.Log("test");
        } else {
            groundNormal = new Vector2(0,1);
        }


        Debug.DrawLine(transform.position, transform.position+(Vector3)groundNormal);
        body.AddForce(groundNormal * Physics2D.gravity[1] * body.mass);



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





    public static Vector2 rotate(Vector2 v, float angle) {
        float delta = angle * Mathf.Deg2Rad;
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }


}
