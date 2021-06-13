using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public bool InDeadZone;
    public bool Death;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Death")
        {
            InDeadZone = true;
        }
        if (collision.tag == "FallDeath")
        {
            print(this.GetComponent<Rigidbody2D>().velocity.y );
            if(this.GetComponent<Rigidbody2D>().velocity.y<-30)
            {
                Death = true;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            InDeadZone = false;
        }
    }
    
}
