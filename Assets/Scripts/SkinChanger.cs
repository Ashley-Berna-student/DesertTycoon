using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public Color newColor = Color.blue; // The new color to apply to the player
    public string playerTag = "Player"; // The tag of the player GameObject

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag 'Player'
        if (other.CompareTag(playerTag))
        {
            // Get the player GameObject
            GameObject player = other.gameObject;

            // Find the child GameObject named 'Body' (adjust the name as needed)
            Transform body = player.transform.Find("Body");

            // Check if the child GameObject is found
            if (body != null)
            {
                // Get the Renderer component of the child GameObject
                Renderer renderer = body.GetComponent<Renderer>();

                // Check if the Renderer component is found
                if (renderer != null)
                {
                    // Change the color of the material
                    renderer.material.color = newColor;
                    print("changed color");
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on Body GameObject.");
                }
            }
            else
            {
                Debug.LogWarning("Body GameObject not found as a child of the player.");
            }
        }
    }
}
