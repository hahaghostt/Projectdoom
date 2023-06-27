using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour 
{

    public float mouseSensitivity = 100f;

    public Transform playerBody; //This for the x axis moving the player body and the cameras at the same time 

    float xRotation = 0f;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    float mouseX = 0f;
    float mouseY = 0f;

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKey(KeyCode.D)) {
            mouseX -= Time.deltaTime;
        } else if (Input.GetKey(KeyCode.G)) {
            mouseX += Time.deltaTime;
        } else {
            mouseX = 0f;
        }

        if (Input.GetKey(KeyCode.R)) {
            mouseY += Time.deltaTime;
        } else if (Input.GetKey(KeyCode.F)) {
            mouseY -= Time.deltaTime;
        } else {
            mouseY = 0f;
        }

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //WE CANT OVER ROTATE BEHIND THE PLAYER

        //Every frame will decrease our x rotation on mouse Y by haven it decrease it wont flip the rotation you must have it decreasing


       //Time.deltaTime means that it checks the last time the void update has been updated and then with this it calls the update function
       //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; QUATERION IS RESPONSIBLE FOR ROTATION UNITY

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
