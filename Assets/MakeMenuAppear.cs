using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMenuAppear : MonoBehaviour
{
    public GameObject Menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==22)
        {
            Menu.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
