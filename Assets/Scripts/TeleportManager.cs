using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public TeleportPlayer teleportPlayer;

    // Example method to trigger teleportation
    public void TriggerTeleport()
    {
        teleportPlayer.Teleport();
    }
}
