using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    public float speed = 5f;
    public float rotationSpeed = 300f;
    public Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController component is missing on this GameObject.");
        }

        if (cam == null)
        {
            Debug.LogError("Camera Transform is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        if (controller == null || cam == null)
        {
            return; // Exit update if required components are not assigned
        }

        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Rotate the player based on horizontal input
        transform.Rotate(Vector3.up * horizontal);

        // Calculate the forward movement direction
        Vector3 forwardMovement = transform.forward * vertical;

        // Ensure there's no vertical movement
        forwardMovement.y = 0f;

        // Move the player
        controller.Move(forwardMovement);
    }

    // Method to get the current player rotation
    public Quaternion GetPlayerRotation()
    {
        return transform.rotation;
    }
}
