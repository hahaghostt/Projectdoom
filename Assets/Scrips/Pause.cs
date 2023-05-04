using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Pause : MonoBehaviour
{
    public GameObject menu;
    public GameObject resume;
    public GameObject LoadMenuu; 
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
    public void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        off = true;
        on = false;
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit"); 
    }
}
