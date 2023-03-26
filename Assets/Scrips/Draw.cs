using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Animator draw;
    public GameObject openText;
    public bool inReach;
    public AudioSource drawSound;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()

    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DrawOpens();
        }
        else
        {
            DrawClose();
        }
    }
    void DrawOpens()
    {
        Debug.Log("It Openes");
        draw.SetBool("open", true);
        drawSound.Play();
    }

    void DrawClose()
    {
        draw.SetBool("open", false);
    }
}