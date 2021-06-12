using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform ActivePlayer;
    Vector3 offset = new Vector3(-20.1f,-3.1f,-33.5f);
    public float ActivationDistance = 10;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, ActivePlayer.position+offset, ref velocity, smoothTime);
    }
}
