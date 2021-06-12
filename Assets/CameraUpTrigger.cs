using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpTrigger : MonoBehaviour
{
    public Transform PositionForCam;
    public bool IsTriggerr = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>()!=null)
        {
            Camera.main.GetComponent<CameraTransition>().DoTransition();
        }
    }
    private void Update()
    {
        if(IsTriggerr)
        {
            Camera.main.GetComponent<CameraTransition>().DoTransition();
        }
    }
}
