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
    }

    public void Update()
    {
        if (textObvj.text == "Right" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("its open");
        }
        
        if(keyPadObvj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            FPScontroller.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        
        
        
    }




    // Update is called once per frame
   // voidUpdate()
   // {
        
   // }
}
