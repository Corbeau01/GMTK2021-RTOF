using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //music 1-10seconds fade down
    //music 2-FadeIn
    //Volume pour chaque

    public AudioClip[] Musics;
    public AudioClip[] sfx;

    public AudioSource Source1;
    public AudioSource Source2;
    public AudioSource BackGroundSource;

    public AudioSource SfxGame;

    [Range(0,1)]
    public float Music1Volume;
    [Range(0, 1)]
    public float Music2Volume;
    [Range(0, 1)]
    public float Music3Volume;

    
    public float FadeTime = 1f;

    bool FirstSongIsPlaying = true;
    AudioClip NextSong;
    AudioClip CurrentSong;
    float SoundLenght;
    public float CurrentTimer=0.001f;
    bool StartTimer = false;

    int StartFadingIncrement = 0;
    public bool startFading = false;
    public bool isFading = false;
    public bool EndFading = false;

    public float TotalSongLenght;
    public float Currnttraker;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            EndFading = false;
            CurrentSong = Musics[0];
            NextSong = Musics[1];
            Source1.PlayOneShot(CurrentSong);
            SoundLenght = Musics[0].length;
            StartTimer=true;
            
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 10;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Time.timeScale = 1;
        }
        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
        }
        if(CurrentTimer>=SoundLenght-10)
        {
            isFading = true;
            if(StartFadingIncrement<1)
            {
                startFading = true;
                StartFadingIncrement++;
            }

            //CurrentTimer = 0;
            TotalSongLenght = SoundLenght;
            Currnttraker = CurrentTimer;
        }
        if(isFading)
        {

            if (FirstSongIsPlaying)
            {
                FadeOut(Source1);
                FadeIn(Source2);
                
                if(startFading)
                {
                    
                    Source2.PlayOneShot(NextSong);
                    SoundLenght = Musics[1].length;
                    CurrentTimer = 0;
                    startFading = false;
                }
                
            }
            else
            {
               
                FadeOut(Source2);
                FadeIn(Source1);
                SoundLenght = Musics[0].length;
                
                if (startFading)
                {
                    Source1.PlayOneShot(CurrentSong);
                    SoundLenght = Musics[0].length;
                    CurrentTimer = 0;
                    startFading = false;
                }

            }
        }
        if(EndFading)
        {
            isFading = false;
            CurrentTimer = 0;
            StartFadingIncrement = 0;
            FirstSongIsPlaying = !FirstSongIsPlaying;
            EndFading = false;
        }
        Source1.volume = Source1.volume * Music1Volume;
        Source2.volume = Source2.volume * Music2Volume;
    }


    float T;
    public void FadeOut(AudioSource source)
    {
        T += Time.deltaTime;
        
        if(source.volume>0)
        {
            if (T > 1f)
            {
                Source1.volume -= 0.1f;
                T = 0;
            }
            
        }
        else
        {
            EndFading=true;
        }
        
    }
    public void FadeIn(AudioSource source)
    {
        T += Time.deltaTime;

        if (source.volume < 1)
        {
            if (T > 1f)
            {
                Source1.volume += 0.1f;
                T = 0;
            }

        }
        else
        {
            EndFading=true;
        }
    }
}
