using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "I'm an interactable object!";
    public UnityEvent onInteract = new UnityEvent();
    public GameObject[] associatedObjects;
    public GameObjectActivationManager activationManager;

    private bool interacted = false;

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        if (!interacted)
        {
            onInteract.Invoke();
            interacted = true;

            // Activate associated objects
            foreach (GameObject obj in associatedObjects)
            {
                obj.SetActive(true);
            }

            // Check if activation condition is met
            if (activationManager != null)
            {
                activationManager.requiredObjects = associatedObjects; // Set requiredObjects to associatedObjects
            }
        }
    }
}
