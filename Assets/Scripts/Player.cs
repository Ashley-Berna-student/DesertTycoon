using UnityEngine;

namespace Money
{
    public class Player : MonoBehaviour
    {
        [SerializeField] public int gold;

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
