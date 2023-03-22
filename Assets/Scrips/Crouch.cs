using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;

    // Start is called before the first frame update
    void Start()
    {
        characterCollider = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.LeftControl))
       {
            characterCollider.height = 0.4f;
       }
       else
       {
            characterCollider.height = 3.8f;
       }
    }
}
