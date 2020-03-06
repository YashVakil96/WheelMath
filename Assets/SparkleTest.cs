using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleTest : MonoBehaviour
{
    public ParticleSystem Sparkle;
    public AudioClip ONESHOT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Sparkle.Play();
            //if(Sparkle.particleCount>=0)
            //{
            //    if (this.gameObject.GetComponent<AudioSource>().isPlaying)
            //    {
            //        this.gameObject.AddComponent<AudioSource>();
            //        GetComponent<AudioSource>().PlayOneShot(ONESHOT);
            //    }
            //    else
            //    {
            //        GetComponent<AudioSource>().PlayOneShot(ONESHOT);
            //    }
            //}
        }
    }
}
