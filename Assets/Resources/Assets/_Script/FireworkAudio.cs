using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkAudio : MonoBehaviour
{
    #region Variable
    public AudioClip SingleShot;

    private bool Played;
    [SerializeField]
    private int Count;
    #endregion

    #region System Methods
    private void Update()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            if (this.GetComponent<ParticleSystem>().particleCount > 0)
            {
                this.GetComponent<AudioSource>().PlayOneShot(SingleShot);
            }
        }
        Count = this.GetComponent<ParticleSystem>().particleCount;
    }
    #endregion

    #region User Define Methods
    #endregion
}
