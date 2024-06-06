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
    }
}
