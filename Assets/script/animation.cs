using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{

    Rigidbody2D rb; 
    Animator anim;
    SfxManager sfxm;
    int animState = 0;
    bool IsTouchingWall = false;
    // 0 = idle, 1 = walking, 2 = running, 3 = jump, 4 = fall, 5 = landing, 6 = collide 

    bool CurrentDir = false;
    // false = forward, true = back

    // Start is called before the first frame update


    void Start()
    {
        //sfxm = FindObjectOfType<SfxManager>();
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void setIdle() 
    {
        animState = 0; 
    }

    public void setWalk()
    {
        animState = 1; 
    }

    public void setRun()
    {
        animState = 2;
    }

    public void setJump()
    {
        animState = 3;
        
    }

    public void setFall()
    {
        animState = 4;
    }

    public void setLand()
    {
        animState = 5;
    }

    public void setCollide()
    {
        animState = 6; 
    }

    private void Update()
    {

        //set direction of player

        if(Input.GetKey(KeyCode.A) && (CurrentDir == true))
        {
            Vector3 reverseScale = this.gameObject.transform.localScale;
            reverseScale.x = Mathf.Abs(reverseScale.x) * -1;
            this.gameObject.transform.localScale = reverseScale;

            Vector3 reversePosition = this.gameObject.transform.position;
            reversePosition.x += 0.4f;
            this.gameObject.transform.position = reversePosition;
            CurrentDir = false;
        }
        if (Input.GetKey(KeyCode.D) && (CurrentDir == false))
        {
            Vector3 forwardScale = this.gameObject.transform.localScale;
            forwardScale.x = Mathf.Abs(forwardScale.x);
            this.gameObject.transform.localScale = forwardScale;

            Vector3 forwardPosition = this.gameObject.transform.position;
            forwardPosition.x -= 0.4f;
            this.gameObject.transform.position = forwardPosition;

            CurrentDir = true; 
        }

        if (rb.velocity.x>0.1 || rb.velocity.x < -0.1)
        {
            setWalk();
            //sfxm.PlaySFXBruitDePas();
        }
        if (rb.velocity.x > 3 || rb.velocity.x < -3)
        {
            setRun();
            //sfxm.PlaySFXBruitDeCourse();
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            setJump();
           
            //sfxm.PlaySFXJump();
        }
        if(rb.velocity.y < -0.1)
        {
            setFall();
            //sfxm.PlaySFXEnTrainDeTomber();
        }
        if(rb.velocity.magnitude<0.1)
        {
            setIdle(); 
        }
        if (anim != null)
        {
            anim.SetInteger("state", animState);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer==20)
        {
            IsTouchingWall = true;
        }
    }
    private void OnCollisionStay2D(Collision collision)
    {
        if (collision.gameObject.layer == 19)
        {
            IsTouchingWall = false;
        }
    }
    void CheckForClimb()
    {
        if(IsTouchingWall)
        {
            if(this.GetComponent<Rigidbody2D>().velocity.y==0)
            {
                //immobile
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                //Going up
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                //Going Down
            }
        }
    }
}



