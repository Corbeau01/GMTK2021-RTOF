using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool IsActivated = false;
    int JumpPower = 200;
    int speed = 1;
    void Update()
    {
        if(!IsActivated)
        {
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W))
        {
            //this.GetComponent<Animator>().SetInteger("State", 1);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up*JumpPower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*-1 * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
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
