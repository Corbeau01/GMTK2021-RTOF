using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float Frac;
    private void Start()
    {
        Frac = 0f;
    }
    private void Update()
    {
        Frac += 0.15f*Time.deltaTime;
        Color NewColor = Color.Lerp(Color.white, Color.clear,Frac);

        this.GetComponent<SpriteRenderer>().color = NewColor;
        if(Frac>=1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
