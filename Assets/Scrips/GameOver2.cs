using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Retry()
    {
        SceneManager.LoadScene("Lvl 2");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }


}