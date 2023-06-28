using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keyPadObvj;
    public GameObject hud;
    public GameObject inv;
    public GameObject keyPadUI;


    public GameObject animateObvj;
    public Animator ANI;


    public Text textObvj;
    public string answer = "1234";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public CharacterController FPScontroller;

    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
        keyPadObvj.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        keyPadUI.SetActive(false);
        Cursor.visible = true;
    }

    public void Number(int number)
    {
        textObvj.text += number.ToString();
        button.Play();
    }

    public void Enter()
    {
        if (textObvj.text == answer)
        {
            correct.Play();
            textObvj.text = "Right";
            animate = true; // Set animate to true when the code is correct
        }
        else
        {
            wrong.Play();
            textObvj.text = "Wrong";
        }
    }

    public void Clear()
    {
        {
            textObvj.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keyPadObvj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        FPScontroller.enabled = true;
        keyPadUI.SetActive(false);
    }

    public void Update()
    {
        if (textObvj.text == "Right" && animate)
        {
            ANI.SetBool("animate", true); // Set the "animate" parameter of the door's Animator component to true
            Debug.Log("its open");
        }

        if (keyPadObvj.activeInHierarchy)
        {
            Debug.Log("Functions does run");
            keyPadUI.SetActive(false);
            hud.SetActive(true);
            inv.SetActive(true);
            FPScontroller.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
               if (textObvj.text == answer)
        {
            correct.Play();
            textObvj.text = "Right";
            animate = true; // Set animate to true when the code is correct
        }
        else
        {
            wrong.Play();
            textObvj.text = "Wrong";
        }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            keyPadObvj.SetActive(false);
            inv.SetActive(true);
            hud.SetActive(true);
            FPScontroller.enabled = true;
            keyPadUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.K ) && gameObject.activeInHierarchy)
        { 
            Number(2); 
            Debug.Log("Work!");
        }

          if (Input.GetKeyDown(KeyCode.L) && gameObject.activeInHierarchy)
        { 
            Number(3); 
            Debug.Log("Work!");
        }
          if (Input.GetKeyDown(KeyCode.A ) && gameObject.activeInHierarchy)
        { 
            Number(4); 
            Debug.Log("Work!");
        }
          if (Input.GetKeyDown(KeyCode.S ) && gameObject.activeInHierarchy)
        { 
            Number(5); 
            Debug.Log("Work!");
        }
          if (Input.GetKeyDown(KeyCode.Q ) && gameObject.activeInHierarchy)
        { 
            Number(6); 
            Debug.Log("Work!");
        }

           if (Input.GetKeyDown(KeyCode.W ) && gameObject.activeInHierarchy)
        { 
            Number(7); 
            Debug.Log("Work!");
        }

         if (Input.GetKeyDown(KeyCode.I ) && gameObject.activeInHierarchy)
        { 
            Number(8); 
            Debug.Log("Work!");
        }

             if (Input.GetKeyDown(KeyCode.J ) && gameObject.activeInHierarchy)
        { 
            Number(9); 
            Debug.Log("Work!");
        }

        
    }
}