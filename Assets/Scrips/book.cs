using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    public GameObject bookObj;
    public GameObject invObj;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;
    public bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invObj.SetActive(false);
        pickedUp = false; // initialize pickedUp flag to false
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && !pickedUp)
        {
            bookObj.SetActive(false);
            invObj.SetActive(true);
            keySound.Play();
            pickUpText.SetActive(false);
            pickedUp = true; // set pickedUp flag to true when book is picked up
            Debug.Log("Book picked up: " + pickedUp);
        }
    }
}