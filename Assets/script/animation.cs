using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{

    Animator anim;

    int animState = 0;
    // 0 = idle, 1 = walking, 2 = running, 3 = jump, 4 = fall, 5 = landing, 6 = collide 

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void setIdle() 
    {
        animState = 0; 
    }

    void setWalk()
    {
        animState = 1; 
    }

    void setRun()
    {
        animState = 2;
    }

    void setJump()
    {
        animState = 3;
    }

    void setFall()
    {
        animState = 4;
    }

    void setLand()
    {
        animState = 5;
    }

    void setCollide()
    {
        animState = 6; 
    }

    private void Update()
    {
        anim.SetInteger("state", animState); 
    }
}



