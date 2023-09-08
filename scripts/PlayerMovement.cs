using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to control movement speed

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check for user input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on user input
        Vector3 move = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));
        moveDirection = move * moveSpeed;

        // Apply gravity (if needed)
        if (!controller.isGrounded)
        {
            moveDirection.y -= Time.deltaTime * 5.0f; // Adjust for gravity
        }

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }
}
