using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject quit;

    public bool on;
    public bool off;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        off = true;
        on = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (off && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            off = false;
            on = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (on && Input.GetButtonDown("pause"))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            off = true;
            on = false;
            Cursor.visible = false; 
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        off = true;
        on = false;
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
