using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _reachDistance = 0.2f;

    private bool _eventInvoked;

    private Rigidbody2D _rigidbody2D;
    private Transform _currentTarget;

    public event Action PointReached;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_currentTarget == null)
        {
            return;
        }

        float direction = Mathf.Sign(_currentTarget.position.x - transform.position.x);
        transform.localScale = new Vector3(direction, 1, 1);

        _rigidbody2D.velocity = new Vector2(_moveSpeed * direction, _rigidbody2D.velocity.y);

        if (_eventInvoked == false && Vector2.Distance(transform.position, _currentTarget.position) < _reachDistance)
        {
            _eventInvoked = true;
            PointReached?.Invoke();
        }
    }

    public void SetTarget(Transform target)
    {
        _eventInvoked = false;
        _currentTarget = target;
    }
}