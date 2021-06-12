using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool ActivePlayerKazoo = true;
    public GameObject Kazzoo;
    public GameObject Aza;
    private void Start()
    {
        SetActivation();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Space))
        {
            ActivePlayerKazoo = !ActivePlayerKazoo;
            SetActivation();
        }
    }
    void SetActivation()
    {
        if (ActivePlayerKazoo)
        {
            Kazzoo.GetComponent<PlayerController>().IsActivated = true;
            Aza.GetComponent<PlayerController>().IsActivated = false;
        }
        else
        {
            Aza.GetComponent<PlayerController>().IsActivated = true;
            Kazzoo.GetComponent<PlayerController>().IsActivated = false;
        }
    }
}
