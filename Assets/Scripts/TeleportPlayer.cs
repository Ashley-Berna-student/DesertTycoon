using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float teleportX; // Target X position for teleportation
    public float teleportY; // Target Y position for teleportation
    public float teleportZ; // Target Z position for teleportation

    private Rigidbody playerRigidbody;
    private CharacterController playerController;

    private void Start()
    {
        // Optionally find the player by tag if not set in the inspector
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            if (playerTransform == null)
            {
                Debug.LogError("Player transform is not set and no object with tag 'Player' found.");
                return;
            }
        }

        // Get components if they exist
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();
        playerController = playerTransform.GetComponent<CharacterController>();
    }

    public void Teleport()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = new Vector3(teleportX, teleportY, teleportZ);
            Debug.Log($"Teleporting player to {newPosition}");

            // Disable components if they exist
            if (playerRigidbody != null)
            {
                playerRigidbody.isKinematic = true;
            }

            if (playerController != null)
            {
                playerController.enabled = false;
            }

            // Teleport player
            playerTransform.position = newPosition;

            // Re-enable components
            if (playerRigidbody != null)
            {
                playerRigidbody.isKinematic = false;
            }

            if (playerController != null)
            {
                playerController.enabled = true;
            }

            Debug.Log("Player has been teleported.");
        }
        else
        {
            Debug.LogError("Player transform is not set. Cannot teleport.");
        }
    }
}
