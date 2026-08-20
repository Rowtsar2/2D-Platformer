using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyTargetSelector : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private ProtectionZone _protectionZone;
    
    private int _currentTargetIndex = 0;
    
    private void Start()
    {
        _enemyMovement.SetTarget(_targetPoints[_currentTargetIndex]);
    }
    
    private void OnEnable()
    {
        _protectionZone.PlayerFound += OnPlayerFound;
        _enemyMovement.PointReached += OnPointReached;
        _protectionZone.PlayerLost += OnPlayerLost;
    }

    private void OnDisable()
    {
        _protectionZone.PlayerFound -= OnPlayerFound;
        _enemyMovement.PointReached -= OnPointReached;
        _protectionZone.PlayerLost -= OnPlayerLost;
    }

    private void OnPlayerFound(Transform playerPosition)
    {
        _enemyMovement.PointReached -= OnPointReached;
        _enemyMovement.SetTarget(playerPosition);
    }

    private void OnPlayerLost()
    {
        _enemyMovement.PointReached += OnPointReached;
        _enemyMovement.SetTarget(_targetPoints[_currentTargetIndex]);
    }

    private void OnPointReached()
    {
        SwitchToNextTarget();
        _enemyMovement.SetTarget(_targetPoints[_currentTargetIndex]);
    }
    
    private void SwitchToNextTarget()
    {
        _currentTargetIndex++;
        
        if (_currentTargetIndex >= _targetPoints.Count)
        {
            _currentTargetIndex = 0;
        }
    }
}
