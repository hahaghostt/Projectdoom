using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class DragObject : MonoBehaviour
{
    Vector3 mOffset;
    float mZCoord;
    public GameObject dragText;

    void Start()
    {
        dragText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CompareTag("Box"))
        {

            transform.position = GetMouseWorldPos() + mOffset;
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;

            mOffset = gameObject.transform.position - GetMouseWorldPos();
   
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged with "Draggable"
        if (other.CompareTag("Box"))
        {
            dragText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider is tagged with "Draggable"
        if (other.CompareTag("Box"))
        {
            dragText.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}