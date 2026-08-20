using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerCollector : MonoBehaviour, ICollectorVisitor
{
    private PlayerCollisionHandler _playerCollisionHandler;

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _playerCollisionHandler.OnItemPickedUp += PickUp;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.OnItemPickedUp -= PickUp;
    }

    private void PickUp(Item item)
    {
        item.Accept(this);
    }

    public void Collect(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}