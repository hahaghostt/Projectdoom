using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCollector : MonoBehaviour
{
    public GameObject redFile;
    public GameObject blueFile;
    public GameObject greenFile;
    public GameObject slot;
    public GameObject keyObj;
    public GameObject invObj;
    public GameObject pickUpText;
    public AudioSource keySound;

    private bool hasRedFile = false;
    private bool hasBlueFile = false;
    private bool hasGreenFile = false;
    private bool isSlotOccupied = false;

    private bool inReach = false;

    private void Start()
    {
        pickUpText.SetActive(false);
        invObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == redFile)
        {
            hasRedFile = true;
            Destroy(redFile);
        }
        else if (other.gameObject == blueFile)
        {
            hasBlueFile = true;
            Destroy(blueFile);
        }
        else if (other.gameObject == greenFile)
        {
            hasGreenFile = true;
            Destroy(greenFile);
        }
        else if (other.gameObject == keyObj)
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == keyObj)
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == slot && hasRedFile && hasBlueFile && hasGreenFile && !isSlotOccupied)
        {
            isSlotOccupied = true;
            Instantiate(keyObj, slot.transform.position, Quaternion.identity);
            invObj.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyObj.SetActive(false);
            keySound.Play();
            invObj.SetActive(true);
            pickUpText.SetActive(false);
        }
    }
}