using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkAudio : MonoBehaviour
{
    #region Variable
    public ParticleSystem particle;
    public AudioSource ParticleAudio;
    public AudioClip SingleShot;
    public float Delay;


    private bool Played;
    #endregion

    #region System Methods
    #endregion

    #region User Define Methods
    public void PlayFire()
    {
        ParticleAudio.PlayOneShot(SingleShot);
    }
    #endregion
}
