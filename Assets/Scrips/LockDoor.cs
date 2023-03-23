using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject KeyINV;

    public AudioSource doorsound;
    public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;

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
        inReach = false;
        openText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyINV.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }
        if (hasKey && inReach && Input.GetButtonDown("Interacr"))
        {
            unlocked = true;
            DoorOpens();
        }
        else
        {
            DoorClosed();
        }
        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }
    }
    void DoorOpens()
    {
        if (unlocked)
        {
            door.SetBool("open", true);
            doorsound.Play();
        }
    }

    void DoorClosed()
    {
        if (unlocked)
        {
            door.SetBool("open", false);
        }

    }

}