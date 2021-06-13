using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    bool Text1HasAppear;
    public GameObject Bulle1Go;
    public Sprite[] Bulles1;
    public GameObject Bulle2Go;
    public GameObject Bulle3Go;
    public GameObject Bulle4Go;
    int bulles1Increment = 0;

    public bool Bulle2Trigger = false;
    bool Bulle2HasTrigger;
    float TimerBulle2 = 0;

    public bool Bulle3Trigger = false;
    bool Bulle3HasTrigger;
    float TimerBulle3 = 0;

    public bool Bulle4Trigger = false;
    bool Bulle4HasTrigger;
    float TimerBulle4 = 0;

    private void Start()
    {
        Bulle1Go.GetComponent<SpriteRenderer>().sprite = Bulles1[0];
        
    }
    private void Update()
    {
        if(bulles1Increment<Bulles1.Length-1)
        {
            if (Input.anyKeyDown)
            {
                bulles1Increment++;
                Bulle1Go.GetComponent<SpriteRenderer>().sprite = Bulles1[bulles1Increment];

            }
        }
        else
        {
            Destroy(Bulle1Go);
        }
        if(Bulle2Trigger&&!Bulle2HasTrigger)
        {
            
            Bulle2Go?.SetActive(true);
            TimerBulle2 += Time.deltaTime;
        }
        if(TimerBulle2>5f)
        {
            Bulle2HasTrigger = true;
            TimerBulle2 = 0;
            Bulle2Go?.SetActive(false);
        }
        if (Bulle3Trigger && !Bulle3HasTrigger)
        {

            Bulle3Go?.SetActive(true);
            TimerBulle3 += Time.deltaTime;
        }
        if (TimerBulle3 > 5f)
        {
            Bulle3HasTrigger = true;
            TimerBulle3 = 0;
            Bulle3Go?.SetActive(false);
        }
        if (Bulle4Trigger && !Bulle4HasTrigger)
        {

            Bulle4Go?.SetActive(true);
            TimerBulle4 += Time.deltaTime;
        }
        if (TimerBulle4 > 5f)
        {
            Bulle4HasTrigger = true;
            TimerBulle4 = 0;
            Bulle4Go?.SetActive(false);
        }
    }
}
