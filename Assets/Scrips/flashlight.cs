using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject flashLight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;

    void Start()
    {
        off = true;
        flashLight.SetActive(false);
    }

    void Update()
    {
        if (off && Input.GetKeyDown(KeyCode.C))
        {
            flashLight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetKeyDown(KeyCode.C))
        {
            flashLight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
}