using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> IsTake;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var Player))
        {
            IsTake?.Invoke(this);
        }
    }
}
