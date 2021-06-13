using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{

    Animator anim;
    SfxManager sfxm;
    int animState = 0;
    // 0 = idle, 1 = walking, 2 = running, 3 = jump, 4 = fall, 5 = landing, 6 = collide 

    // Start is called before the first frame update


    void Start()
    {
        sfxm = FindObjectOfType<SfxManager>();
        anim = this.gameObject.GetComponent<Animator>();
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
        if(GetComponent<Rigidbody2D>().velocity.x>0&& GetComponent<Rigidbody2D>().velocity.x<4)
        {
            setWalk();
            sfxm.PlaySFXBruitDePas();
        }
        if (GetComponent<Rigidbody2D>().velocity.x > 4)
        {
            setRun();
            sfxm.PlaySFXBruitDeCourse();
        }
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.Space))
        {
            setJump();
            sfxm.PlaySFXJump();
        }
        if(GetComponent<Rigidbody2D>().velocity.y<0)
        {
            setFall();
            sfxm.PlaySFXEnTrainDeTomber();
        }
        
        anim.SetInteger("state", animState); 
    }
}



