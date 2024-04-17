using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Jump Force")]
    [SerializeField] private int _platformSpawnCountAtStart = 10;

    [Header("Spawn Random Coordinates X")]
    [SerializeField] private float _minPositionX = -13f;
    [SerializeField] private float _maxPositionX = 13f;

    [Header("Spawn Random Coordinates Y")]
    [SerializeField] private float _minPositionY = -1f;
    [SerializeField] private float _maxPositionY = 10f;

    [Header("Offset Position Y Upadte")]
    [SerializeField] private float _offsetPositionY = 40f;

    [Header("Regular Platforms")]
    [SerializeField] private GameObject _platformPrefab;
    
    private void Start()
    {
        Vector3 SpawnPosition = new Vector3();

        for (int i = 0; i < _platformSpawnCountAtStart; i++)
        {
            SpawnPosition.x = Random.Range(_minPositionX, _maxPositionX);
            SpawnPosition.y += Random.Range(_minPositionY, _maxPositionY);

            Instantiate(_platformPrefab, SpawnPosition, Quaternion.identity);
        }
    }
}
