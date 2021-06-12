using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRope : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;
    public float LineLenght;
    public float Elasticite=0.1f;
    public float Force;
    LineRenderer LR;

    bool KazzoIsFollower = true;
    Transform Folower;
    Transform Leader;
    bool IsClose = false;
    private void Start()
    {
        LR = this.GetComponent<LineRenderer>();
    }
    private void Update()
    {
        LR.SetPosition(0, Player1.position);
        LR.SetPosition(1, Player2.position);
        LineLenght = Vector2.Distance(Player1.position, Player2.position);
        Force = LineLenght * Elasticite;
        
       
        if(Input.GetKeyDown(KeyCode.Q))
        {
            KazzoIsFollower = !KazzoIsFollower;
        }
        if(KazzoIsFollower)
        {
            Folower = Player1;
            Leader = Player2;
        }
        else
        {
            Folower = Player2;
            Leader = Player1;
        }

        Folower.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (LineLenght<2&&IsClose==false)
        {
            Folower.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            IsClose = true;
        }
        else
        {
            Folower.gameObject.GetComponent<Rigidbody2D>().AddForce(Leader.position * Force);
            IsClose = false;
        }
    }
}
