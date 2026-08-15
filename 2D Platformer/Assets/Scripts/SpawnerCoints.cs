using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerCoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Coin _coinPrefab;

    private Transform _currentSpawnPosition;
    private Coin _currentCoin;
    
    private void Start()
    {
        SpawnCoin(null);
    }


    private void SpawnCoin(Coin oldCoin)
    {
        if (oldCoin != null)
        {
            oldCoin.IsTake -= SpawnCoin;
            Destroy(oldCoin.gameObject);
        }

        _currentCoin = Instantiate(_coinPrefab, GetRandomPosition().position, Quaternion.identity);
        _currentCoin.IsTake += SpawnCoin;
    }
    
    private Transform GetRandomPosition()
    {
        Transform newPosition;

        do
        {
            newPosition = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        } 
        while (newPosition == _currentSpawnPosition);

        return _currentSpawnPosition = newPosition;
    }
}