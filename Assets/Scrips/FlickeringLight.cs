using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{


    public Light _Light; // The Light You Want To Flicker.
    public float MinTime; // Minimum value that the timer can have.
    public float MaxTime; // Maximum value that the timer can have.
    public float Timer; // Timer to flicker the light.
    public AudioSource AS; // AudioSource to play the audio.
    public AudioClip LightAudio; // Audio to play.

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime); 
    }


    void Update()
    {
        FlickerLight(); 
    }

    void FlickerLight()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime; 

        if (Timer <= 0)
        {
            _Light.enabled = !_Light.enabled; 
            Timer = Random.Range(MinTime, MaxTime); 
            AS.PlayOneShot(LightAudio); 
        }
    }
}
