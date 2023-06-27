using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clickchanger : MonoBehaviour
{
    // Start is called before the first frame update
      public void Update ()
    {
        if(Input.GetKeyDown(KeyCode.B)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}