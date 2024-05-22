using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public PlayerMove player; // Reference to the PlayerMove script
    public float distance = 10.0f; // Distance from the player
    public float height = 5.0f; // Height above the player
    public float rotationDamping = 3.0f; // Rotation smoothing
    public float heightDamping = 2.0f; // Height smoothing

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        // Get the player's rotation
        Quaternion playerRotation = player.GetPlayerRotation();
        float wantedRotationAngle = playerRotation.eulerAngles.y;
        float wantedHeight = player.transform.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to distance meters behind the player
        Vector3 position = player.transform.position - currentRotation * Vector3.forward * distance;
        position.y = currentHeight; // Set the height of the camera

        transform.position = position;
        transform.LookAt(player.transform);
    }
}
