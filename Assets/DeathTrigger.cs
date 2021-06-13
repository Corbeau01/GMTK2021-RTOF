using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public bool InDeadZone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Death")
        {
            InDeadZone = true;
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
