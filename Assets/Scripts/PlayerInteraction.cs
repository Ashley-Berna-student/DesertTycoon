using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 2f;
        [SerializeField] private Text interactableName;
        public Player player;

        private InteractionObject targetInteraction;

        void Update()
        {
            Vector3 origin = Camera.main.transform.position;
            Vector3 direction = Camera.main.transform.forward;
            RaycastHit raycastHit;
            string interactionText = " ";
            targetInteraction = null;

            Debug.DrawRay(origin, direction * maxDistance, Color.red); // Visualize the raycast

            if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
            {
                targetInteraction = raycastHit.collider.gameObject.GetComponent<InteractionObject>();
            }

            if (targetInteraction && targetInteraction.enabled)
            {
                interactionText = targetInteraction.GetInteractionText();
            }

            SetInteractableNameText(interactionText);
        }

        private void SetInteractableNameText(string newText)
        {
            if (interactableName)
            {
                interactableName.text = newText;
            }
        }

        public void TryInteract()
        {
            if (targetInteraction == null)
            {
                Debug.LogWarning("No target interaction object found.");
                return;
            }

            if (!targetInteraction.enabled)
            {
                Debug.LogWarning("Target interaction object is not enabled.");
                return;
            }

            if (player == null)
            {
                Debug.LogError("Player reference is not set.");
                return;
            }

            Button_SO button = targetInteraction.GetComponent<Button_SO>();

            if (button == null || player.TryBuy(button))
            {
                targetInteraction.Interact();
            }
            else
            {
                Debug.LogWarning("Player cannot buy the item.");
            }
        }
    }
}
