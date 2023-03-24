using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject HUD;
    public GameObject inv;

    public FPSController fpsController;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;



    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        HUD.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            Debug.Log("Note UI activated.");
            pickUpSound.Play();
            HUD.SetActive(false);
            inv.SetActive(false);
            fpsController.enabled = false;
            Cursor.visible = true; //need change line
            Cursor.lockState = CursorLockMode.None; //need to change line 
        }
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        HUD.SetActive(true);
        inv.SetActive(true);
        fpsController.enabled = true; //change line of code

    }

}