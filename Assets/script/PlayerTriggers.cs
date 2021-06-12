using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bulle2")
        {
            FindObjectOfType<DialogueManager>().Bulle2Trigger = true;
        }
        if (collision.tag == "bulle3")
        {
            FindObjectOfType<DialogueManager>().Bulle3Trigger = true;
        }
        if (collision.tag == "bulle4")
        {
            FindObjectOfType<DialogueManager>().Bulle4Trigger = true;
        }
    }
}
