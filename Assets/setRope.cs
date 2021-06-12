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
        Player1.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player1.gameObject.GetComponent<Rigidbody2D>().AddForce(Player2.position * Force);

        if (LineLenght<2&&IsClose==false)
        {
            Player1.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            IsClose = true;
        }
        else
        {
            Player1.gameObject.GetComponent<Rigidbody2D>().AddForce(Player2.position * Force);
            IsClose = false;
        }
    }
}
