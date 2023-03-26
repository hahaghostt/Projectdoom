using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] public AudioSource walking;

    CharacterController characterController;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Apply gravity
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // Get movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Move the player if the CharacterController is enabled
        if (characterController.enabled)
        {
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        //PlayerFoot steps
        if (IsMoving())
        {
            if (!walking.isPlaying)
            {
                walking.Play();
            }
        }
        else
        {
            walking.Stop();
        }

        // Apply jump force
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        // Apply velocity to the player
        velocity.y += Physics.gravity.y * Time.deltaTime;
        // Move the player if the CharacterController is enabled
        if (characterController.enabled)
        {
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    public bool IsMoving()
    {
        // Returns true if the player is currently moving
        return Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
    }
}






