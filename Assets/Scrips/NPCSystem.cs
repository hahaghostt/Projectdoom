using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool playerDetection = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetection && Input.GetButtonDown("Interact"))
        {
            print("Dialogue");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            playerDetection = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            playerDetection = false;
        }
    }
















}
