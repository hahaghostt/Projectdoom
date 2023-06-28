using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubuttons : MonoBehaviour
{

    // public Image bliCK; 
    public Animator transition;
    public float transitionTime = 1f; 

    public void Update ()
    {
        if(Input.GetKeyDown(KeyCode.V)) 
        {
            LoadNextLevel(); 
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
        }

        if(Input.GetKeyDown(KeyCode.C)) 
        {
            Application.Quit(); 
            Debug.Log("Quit Game"); 
        }
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); 

        yield return new WaitForSeconds(transitionTime); 

        SceneManager.LoadScene(levelIndex);
    }


}
