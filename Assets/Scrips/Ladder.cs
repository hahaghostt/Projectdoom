using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool inside = false;
    public float speed = 12f;
    public CharacterController player;
    [SerializeField] private AudioSource sound;

    void Start()
    {
        player = GetComponent<CharacterController>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Debug.Log("TouchingLadderTrue");
            player.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Debug.Log("TouchingLadderFalse");
            player.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (inside == true && Input.GetKey(KeyCode.W))
        {
            playerController.transform.position += Vector3.up *
                speed * Time.deltaTime;
            if (sound != null)
            {
                sound.enabled = true;
                sound.loop = true;
            }
        }
        else if (inside == true && Input.GetKey(KeyCode.S))
        {
            playerController.transform.position += Vector3.down *
                speed * Time.deltaTime;
            if (sound != null)
            {
                sound.enabled = true;
                sound.loop = true;
            }
        }
        else
        {
            if (sound != null)
            {
                sound.enabled = false;
                sound.loop = false;
            }
        }
    }
}

// Null can also be used to indicate an error condition, such as when a function returns null
// to indicate that it was unable to complete its task successfully. In these cases,
// the null value serves as an indicator that something went wrong and that the calling code needs to handle the error condition appropriately.
