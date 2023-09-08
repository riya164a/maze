using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementWithCamera : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform cameraTransform; // Reference to the main camera's transform

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            // If the cameraTransform reference is not set, assume the main camera
            cameraTransform = Camera.main.transform;
        }
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

        // Update the camera's position to follow the character
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        if (cameraTransform != null)
        {
            // Update the camera's position to follow the character's position
            cameraTransform.position = new Vector3(transform.position.x, cameraTransform.position.y, transform.position.z);
        }
    }
}
