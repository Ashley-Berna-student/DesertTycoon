using UnityEngine;

namespace Money
{
    public class ConveyerObject : MonoBehaviour
    {
        public Player player;
        public int money;

        private void Start()
        {
            player = FindObjectOfType<Player>();
            if (player == null )
            {
                print("cant find player");
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("end"))
            {
                Destroy(gameObject);
                if (player != null)
                {
                    player.gold += money;
                }
                else
                {
                    Debug.LogError("Player reference is not set in ConveyerObject.");
                }
            }
        }
    }
}

