using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSoundManager : MonoBehaviour
{

    private void Start()
    {
        firstSongIsPlaying = true;
        startFadingSing1 = true;
        isFadingSing1 = true;
    }
    public AudioSource Source1;
    public AudioSource Source2;
    public AudioClip[] Songs;


    

    bool Fade1=true;
    bool Fade2;

    public float T;
    public bool startFadingSing1=false;
    public bool isFadingSing1 = false;

    public float T1;
    public bool startFadingSing1Out = false;
    public bool isFadingSing1Out = false;

    public float T2;
    public bool startFadingSing2 = false;
    public bool isFadingSing2 = false;

    public float T22;
    public bool startFadingSing2Out = false;
    public bool isFadingSing2Out = false;

    bool firstSongIsPlaying = false;
    bool secSongIsPlaying = false;

    float Song1Timer;
    float Song2Timer;
    void Fade1stSongin()
    {
        if(startFadingSing1)
        {
            Source1.PlayOneShot(Songs[0]);
            startFadingSing1 = false;
            isFadingSing1 = true;
            firstSongIsPlaying = true;
            secSongIsPlaying = false;
        }
        
        if(Source1.volume<1)
        {
            T += Time.deltaTime;
            if (T >= 1)
            {
                Source1.volume += 0.1f;
                T = 0;
            }
        }
        else
        {
            isFadingSing1 = false;
        }
       
        
    }
    void Fade1stSongOut()
    {
        if (startFadingSing1Out)
        {
            
            startFadingSing1Out = false;
            isFadingSing1Out = true;

        }

        if (Source1.volume > 0.00f)
        {
            T1 += Time.deltaTime;
            if (T1 >= 1)
            {
                Source1.volume -= 0.1f;
                T1 = 0;
            }
        }
        else
        {
            isFadingSing1Out = false;
        }

    }
    void Fade2ndSongIn()
    {
        if (startFadingSing2)
        {
            Source2.PlayOneShot(Songs[1]);
            startFadingSing2 = false;
            isFadingSing2 = true;
            firstSongIsPlaying = false;
            secSongIsPlaying = true;

        }

        if (Source2.volume < 1)
        {
            T2 += Time.deltaTime;
            if (T2 >= 1)
            {
                Source2.volume += 0.1f;
                T2 = 0;
            }
        }
        else
        {
            isFadingSing2 = false;
        }
    }
    void Fade2ndSongOut()
    {
        if (startFadingSing2Out)
        {
            
            startFadingSing2Out = false;
            isFadingSing2Out = true;

        }

        if (Source2.volume >0.00f)
        {
            T22 += Time.deltaTime;
            if (T22 >= 1)
            {
                Source2.volume -= 0.1f;
                T22= 0;
            }
        }
        else
        {
            isFadingSing2Out = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            firstSongIsPlaying = true;
            startFadingSing1 = true;
            isFadingSing1 = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 10;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            startFadingSing2Out = true;
            isFadingSing2Out = true;
        }

        if (isFadingSing1)
        {
            Fade1stSongin();
        }

        if (isFadingSing2)
        {
            Fade2ndSongIn();
        }


        if (isFadingSing1Out)
        {
            Fade1stSongOut();
        }
        if(isFadingSing2Out)
        {
            Fade2ndSongOut();
        }

        if(firstSongIsPlaying)
        {
            Song1Timer += Time.deltaTime;
            if(Song1Timer>=64-10)
            {
                if(Fade1)
                {
                    startFadingSing1Out = true;
                    secSongIsPlaying = false;
                    isFadingSing1Out = true;
                    startFadingSing2 = true;
                    isFadingSing2 = true;
                    firstSongIsPlaying = false;
                    secSongIsPlaying = true;
                    Fade1 = false;
                    Song1Timer = 0;
                    Fade2 = true;
                }
                
            }
        }
        if (secSongIsPlaying)
        {
            Song2Timer += Time.deltaTime;
            if (Song2Timer >= 64 - 10)
            {
                if (Fade2)
                {
                    firstSongIsPlaying = false;
                    secSongIsPlaying = true;
                    startFadingSing2Out = true;
                    isFadingSing2Out = true;
                    startFadingSing1 = true;
                    isFadingSing1 = true;
                    Fade2 = false;
                    Song2Timer = 0;
                    Fade1 = true;
                }

            }
        }
    }
}
