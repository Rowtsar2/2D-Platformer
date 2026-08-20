using System;
using UnityEngine;

public class ProtectionZone : MonoBehaviour
{
    public event Action<Transform> PlayerFound;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            PlayerFound?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
        {
            PlayerLost?.Invoke();
        }
    }
}