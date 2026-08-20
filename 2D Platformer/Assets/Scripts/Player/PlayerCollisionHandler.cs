using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<Item> OnItemPickedUp;
    public event Action<Enemy> OnAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Item>(out var item))
        {
            OnItemPickedUp?.Invoke(item);
        }

        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            OnAttack?.Invoke(enemy);
        }
    }
}

