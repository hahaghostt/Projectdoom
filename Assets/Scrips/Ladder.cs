using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ladder : MonoBehaviour
{

    public Transform playerController;
    bool inside = false;
    public float speed = 3f;
    public AudioSource sound;
    public CharacterController FPSController;

    void Start()
    {
        //FPSController = GetComponent<CharacterController>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("SUSSY");
        if (col.gameObject.tag == "Ladder")
        {
            //Debug.Log("TouchingLadderTrue");
            FPSController.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        

        if (col.gameObject.tag == "Ladder")
        {
            //Debug.Log("TouchingLadderFalse");
            FPSController.enabled = true;
            inside = !inside;
        }
    }

    void Update()
    {
        if (inside == true && Input.GetKey("w"))
        {
            FPSController.transform.position += Vector3.up /
            speed * Time.deltaTime;
        }

        if (inside == true && Input.GetKey("s"))
        {
            FPSController.transform.position += Vector3.down /
            speed * Time.deltaTime;
        }

        if (inside == true && Input.GetKey("w"))
        {
            sound.enabled = true;
            sound.loop = true;
        }
        else
        {
            sound.enabled = false;
            sound.loop = false;
        }
    }
}
