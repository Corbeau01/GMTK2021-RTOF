using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource SfxSource;
    public AudioClip[] SFX;

    public AudioClip BruitDePas;
    public AudioClip Jump;
    public AudioClip Atterrissage;
    public AudioClip QuandOnSaccroche;
    public AudioClip MortDuPerso;

    void PlaySFX(AudioClip Sound)
    {
        if(Sound!=null)
        {
            SfxSource.PlayOneShot(Sound);
        }    
        
    }
}
/*
 * bruits de pas
- jump
- atterissage
- quand on s'accroche
- mort du perso

Activité
*/