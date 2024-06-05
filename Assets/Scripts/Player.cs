using UnityEngine;

namespace Money
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public int gold;
        public float jumpForce = 10f;
        public float gravity = -9.81f;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private CharacterController controller;
        private Vector3 velocity;
        private bool isGrounded;

        public Transform groundCheck;

        public bool TryBuy(Button_SO button)
        {
            if (button != null && gold >= button.cost)
            {
                gold -= button.cost;
                return true;
            }
            return false;
        }

        private void Start()
        {
            controller = GetComponent<CharacterController>();

            if (controller == null)
            {
                Debug.LogError("CharacterController component not found on player.");
            }
        }

        private void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;  // Small value to ensure the player stays grounded
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void Jump()
        {
            if (controller != null)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                Debug.Log("Player jumped with force: " + jumpForce);
            }
            else
            {
                Debug.LogError("CharacterController component is null.");
            }
        }


    }
}
