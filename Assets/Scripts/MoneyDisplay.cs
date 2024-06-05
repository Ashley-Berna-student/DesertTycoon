using Money;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class MoneyDisplay : MonoBehaviour
    {
        public Text moneyText;
        public Player player;  // Reference to the Player script

        void Update()
        {
            // Update the text element with the player's money value
            moneyText.text = "Money: $" + player.gold.ToString("");  // Formatting to 2 decimal places
        }
    }
}
