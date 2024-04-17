using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] private Transform[] _regularSpawnPoints;
    [SerializeField] private Transform[] _middleSpawnPoints;
    [SerializeField] private Transform[] _bigSpawnPoints;

    [Header("Count Enemies")]
    [SerializeField] private int _regularEnemiesCount = 1;
    [SerializeField] private int _middleEnemiesCount = 1;
    [SerializeField] private int _bigEnemiesCount = 1;

    [Header("Prefabs")]
    [SerializeField] private GameObject _regularEnemy;
    [SerializeField] private GameObject _middleEnemy;
    [SerializeField] private GameObject _bigEnemy;

    private void Start()
    {
        for (int  i = 0; i < _regularSpawnPoints.Length; i++)
        {
            for (int j = 0; j < _regularEnemiesCount; j++)
            {
                Instantiate(_regularEnemy, _regularSpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
