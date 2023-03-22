using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening: MonoBehaviour
{
    public Animator ventObj;
    public GameObject screwObjNeeded;
    public GameObject OpenText;
    public GameObject screwMissingText;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        OpenText.SetActive(false);
        screwMissingText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            OpenText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            OpenText.SetActive(false);
            screwMissingText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (screwObjNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            OpenText.SetActive(false);
            openSound.Play();
            ventObj.SetBool("open", true);
            OpenText.SetActive(false);
            isOpen = true;
        }
        
        else if (screwObjNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            OpenText.SetActive(false);
            screwMissingText.SetActive(true);
        }
        if(isOpen)
        {
            ventObj.GetComponent<BoxCollider>().enabled = false;
            ventObj.GetComponent<Opening>().enabled = false;
        }

    }
}
