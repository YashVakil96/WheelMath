using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSparkle : MonoBehaviour
{
    public AudioClip ONESHOT;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            if (this.GetComponent<ParticleSystem>().particleCount > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(ONESHOT);
            }
        }
    }
}
