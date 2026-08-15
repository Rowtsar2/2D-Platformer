using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovment : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private float _moveSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private int _currentTarget = 0;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float derection = _targetPoints[_currentTarget].position.x - transform.position.x;
        transform.localScale = new Vector3(Mathf.Sign(derection), 1, 1);
        
        Vector2 newPosition = Vector2.MoveTowards(_rigidbody2D.position, _targetPoints[_currentTarget].position,
            _moveSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(newPosition);

        if (Vector2.Distance(transform.position, _targetPoints[_currentTarget].position) < 0.2f)
        {
            SetNextTarget();
        }
    }

    private void SetNextTarget()
    {
        _currentTarget++;
        
        if (_currentTarget >= _targetPoints.Count)
        {
            _currentTarget = 0;
        }
    }
}
