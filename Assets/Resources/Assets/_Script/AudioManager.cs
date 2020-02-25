using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    public static bool UpSound;

    public AudioClip NormalLine;
    public AudioClip UpLine;

    private AudioSource Audio;
    #endregion

    #region System Methods

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    #endregion

    #region User Define Methods
    public void PlaySound()
    {
        if(UpSound)
        {
            //Upsound
            Audio.clip = UpLine;
            Audio.loop = false;
            Audio.Play();
        }
        else
        {
            //normalSound
            Audio.clip = NormalLine;
            Audio.loop = false;
            Audio.Play();
        }
    }
    public void PlayFireWorks()
    {

    }

    #endregion

}
