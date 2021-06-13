using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource SfxSource;
    public AudioClip[] SFX;

    public AudioClip BruitDePas;
    public AudioClip BruitDeCourse;
    public AudioClip Jump;
    public AudioClip Atterrissage;
    public AudioClip QuandOnSaccroche;
    public AudioClip MortDuPerso;
    public AudioClip EnTrainDeTomber;

    public void PlaySFXBruitDePas()
    {
        if(BruitDePas!=null)
        {
            SfxSource.PlayOneShot(BruitDePas);
        }
        
    }
    public void PlaySFXJump()
    {
        if (Jump != null)
        {
            SfxSource.PlayOneShot(Jump);
        }

    }
    public void PlaySFXAtterrissage()
    {
        if (Atterrissage != null)
        {
            SfxSource.PlayOneShot(Atterrissage);
        }

    }
    public void PlaySFXQuandOnSaccroche()
    {
        if (QuandOnSaccroche != null)
        {
            SfxSource.PlayOneShot(QuandOnSaccroche);
        }

    }
    public void PlaySFXMortDuPerso()
    {
        if (MortDuPerso != null)
        {
            SfxSource.PlayOneShot(MortDuPerso);
        }

    }
    public void PlaySFXBruitDeCourse()
    {
        if (MortDuPerso != null)
        {
            SfxSource.PlayOneShot(BruitDeCourse);
        }

    }
    public void PlaySFXEnTrainDeTomber()
    {
        if (MortDuPerso != null)
        {
            SfxSource.PlayOneShot(EnTrainDeTomber);
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