using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UpdateGenerator : MonoBehaviour
{
    [Header("Update Generator Position")]
    [SerializeField] private float _offsetPositionY = 50f;

    [Header("Spawn Random Coordinates X")]
    [SerializeField] private float _minPositionX = -13f;
    [SerializeField] private float _maxPositionX = 13f;

    [Header("Offset Platform Position Y")]
    [SerializeField] private float _minOffsetPlatformPositionY = 0f;
    [SerializeField] private float _maxOffsetPlatformPositionY = 50f;

    [Header("Count Platform")]
    [SerializeField] private int _regularPlatformSpawnCount = 5;
    [SerializeField] private int _destroyedPlatformSpawnCount = 2;
    [SerializeField] private int _hidingPlatformSpawnCount = 2;
    [SerializeField] private int _spikedPlatformSpawnCount = 2;

    [Header("Regular Platform")]
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private int _maxRegularPlatformProbability = 10;

    [Header("Destroyed Platform")]
    [SerializeField] private GameObject _platformDestroyedPrefab;
    [SerializeField] private int _maxDestroyPlatformProbability = 50;

    [Header("Super Jump Platform")]
    [SerializeField] private GameObject _superJumpPlatformPrefab;
    [SerializeField] private int _maxSuperJumpPlatformProbability = 50;

    [Header("Hiding Platform")]
    [SerializeField] private GameObject _hidingPlatformPrefab;
    [SerializeField] private int _maxHidingPlatformProbability = 500;

    [Header("Spiked Platform")]
    [SerializeField] private GameObject _spikedPlatformPrefab;
    [SerializeField] private int _maxSpikedPlatformProbability = 100;

    [Header("Guns")]
    [SerializeField] private GameObject _leftGunPrefab;
    [SerializeField] private GameObject _rightGunPrefab;
    
    [Header("Coordinates for Guns")]
    [SerializeField] private int _gunCount = 1;
    [SerializeField] private float _leftPositionX = -13f;
    [SerializeField] private float _rightPositionX = 13f;
    [SerializeField] private float _verticalOffsetPositionY = 10f;
    [SerializeField] private int _gunProbability = 100;
    
    [Header("Bird")]
    [SerializeField] private GameObject _birdPrefab;
    [SerializeField] private int _maxBirdProbability = 20;
    [SerializeField] private float _verticalEnemyOffsetPostionY;
    [SerializeField] private Transform _targets;

    [Header("Patrolling Enemy")]
    [SerializeField] private GameObject _patrolingEnemyPrefab;
    [SerializeField] private int _maxPatrollingProbability = 20;
    [SerializeField] private float _verticalPatrollingEnemyOffsetY;

    [Header("Static Enemy")]
    [SerializeField] private GameObject _staticEnemyPrefab;
    [SerializeField] private int _maxStaticProbability = 20;
    [SerializeField] private float _verticalStaticEnemyOffsetY;

    [Header("Rare Coin")]
    [SerializeField] private GameObject _rareCoinPrefab;
    [SerializeField] private float _rareCoinOffsetY = 2f;
    [SerializeField] private int _rareCoinProbability = 10;

    [Header("Middle Coin")]
    [SerializeField] private GameObject _middleCoinPrefab;
    [SerializeField] private float _middleCoinOffsetY = 2f;
    [SerializeField] private int _middleCoinProbability = 4;

    [Header("Regular Coin")]
    [SerializeField] private GameObject _regularCoinPrefab;
    [SerializeField] private float _regularCoinOffsetY = 2f;
    [SerializeField] private int _regularCoinProbability = 4;

    [Header("Shield")]
    [SerializeField] private GameObject _shieldBonuce;
    [SerializeField] private float _shieldOffsetY = 2f;
    [SerializeField] private int _shieldProbability = 20;

    [Header("Jetpack")]
    [SerializeField] private GameObject _jetpackBonuce;
    [SerializeField] private float _jetpackOffsetY = 2f;
    [SerializeField] private int _probabilityJetpack = 30;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            CreateAdditionPlatforms();
            transform.position = new Vector3(transform.position.x, transform.position.y + _offsetPositionY, transform.position.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _offsetPositionY, transform.position.z);
        }
    }

    private void CreateAdditionPlatforms()
    {
        //int spikedPlatformProbability = Random.Range(0, _maxSpikedPlatformProbability);
        int regularPlatformProbability = Random.Range(0, _maxRegularPlatformProbability);
        int destroyPlatformProbability = Random.Range(0, _maxDestroyPlatformProbability);
        int hidingPlatformProbability = Random.Range(0, _maxHidingPlatformProbability);
        int superJumpPlatformProbability = Random.Range(0, _maxSuperJumpPlatformProbability);

        int regularCoinProbability = Random.Range(0, _regularCoinProbability);
        int middleCoinProbability = Random.Range(0, _middleCoinProbability);
        int rareCoinProbability = Random.Range(0, _rareCoinProbability);
        int shieldProbability = Random.Range(0, _shieldProbability);
        int jetpackProbability = Random.Range(0, _probabilityJetpack);

        if (regularPlatformProbability == 1)
        {
            for (int i = 0; i < _regularPlatformSpawnCount; i++)
            {
                Transform platformPosition = Instantiate(_platformPrefab, transform.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), Random.Range(_minOffsetPlatformPositionY, _maxOffsetPlatformPositionY), transform.position.z), Quaternion.identity).transform;

                if (rareCoinProbability == 1)
                {
                    Instantiate(_rareCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _rareCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (middleCoinProbability == 1)
                {
                    Instantiate(_middleCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _middleCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (regularCoinProbability == 1)
                {
                    Instantiate(_regularCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _regularCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (shieldProbability == 1)
                {
                    Instantiate(_shieldBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _shieldOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (jetpackProbability == 1)
                {
                    Instantiate(_jetpackBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (superJumpPlatformProbability == 1)
                {
                    Instantiate(_superJumpPlatformPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }
            }
        }

        if (destroyPlatformProbability == 1)
        {
            for (int i = 0; i < _destroyedPlatformSpawnCount; i++)
            {
                Transform platformPosition = Instantiate(_platformDestroyedPrefab, transform.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), Random.Range(_minOffsetPlatformPositionY, _maxOffsetPlatformPositionY), transform.position.z), Quaternion.identity).transform;

                if (rareCoinProbability == 1)
                {
                    Instantiate(_rareCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _rareCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (middleCoinProbability == 1)
                {
                    Instantiate(_middleCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _middleCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (regularCoinProbability == 1)
                {
                    Instantiate(_regularCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _regularCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (shieldProbability == 1)
                {
                    Instantiate(_shieldBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _shieldOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (jetpackProbability == 1)
                {
                    Instantiate(_jetpackBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (superJumpPlatformProbability == 1)
                {
                    Instantiate(_superJumpPlatformPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }
            }
        }

        if (hidingPlatformProbability == 1)
        {
            for (int i = 0; i < _hidingPlatformSpawnCount; i++)
            {
                Transform platformPosition = Instantiate(_hidingPlatformPrefab, transform.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), Random.Range(_minOffsetPlatformPositionY, _maxOffsetPlatformPositionY), transform.position.z), Quaternion.identity).transform;

                if (rareCoinProbability == 1)
                {
                    Instantiate(_rareCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _rareCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (middleCoinProbability == 1)
                {
                    Instantiate(_middleCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _middleCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (regularCoinProbability == 1)
                {
                    Instantiate(_regularCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _regularCoinOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (shieldProbability == 1)
                {
                    Instantiate(_shieldBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _shieldOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (jetpackProbability == 1)
                {
                    Instantiate(_jetpackBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }

                if (superJumpPlatformProbability == 1)
                {
                    Instantiate(_superJumpPlatformPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
                    return;
                }
            }
        }

        //if (spikedPlatformProbability == 1)
        //{
        //    for (int i = 0; i < _spikedPlatformSpawnCount; i++)
        //    {
        //        Transform platformPosition = Instantiate(_spikedPlatformPrefab, transform.position + new Vector3(Random.Range(_minPositionX, _maxPositionX), Random.Range(_minOffsetPlatformPositionY, _maxOffsetPlatformPositionY), transform.position.z), Quaternion.identity).transform;

        //        if (rareCoinProbability == 1)
        //        {
        //            Instantiate(_rareCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _rareCoinOffsetY, platformPosition.position.z), Quaternion.identity);
        //            return;
        //        }

        //        if (middleCoinProbability == 1)
        //        {
        //            Instantiate(_middleCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _middleCoinOffsetY, platformPosition.position.z), Quaternion.identity);
        //            return;
        //        }

        //        if (regularCoinProbability == 1)
        //        {
        //            Instantiate(_regularCoinPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _regularCoinOffsetY, platformPosition.position.z), Quaternion.identity);
        //            return;
        //        }

        //        if (shieldProbability == 1)
        //        {
        //            Instantiate(_shieldBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _shieldOffsetY, platformPosition.position.z), Quaternion.identity);
        //            Debug.Log("Work Hiding");
        //            return;
        //        }

        //        if (jetpackProbability == 1)
        //        {
        //            Instantiate(_jetpackBonuce, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
        //            Debug.Log("Work Regular");
        //            return;
        //        }

        //        if (superJumpPlatformProbability == 1)
        //        {
        //            Instantiate(_superJumpPlatformPrefab, new Vector3(platformPosition.position.x, platformPosition.position.y + _jetpackOffsetY, platformPosition.position.z), Quaternion.identity);
        //            Debug.Log("Work Regular");
        //            return;
        //        }
        //    }
        //}

        CreateEnemies();
        CreateSlowPlatform();
    }

    private void CreateEnemies()
    {
        int birdEnemyProbability = Random.Range(0, _maxBirdProbability);
        int staticEnemyProbability = Random.Range(0, _maxStaticProbability);
        int patrollingEnemyProbability = Random.Range(0, _maxPatrollingProbability);

        if (birdEnemyProbability == 1)
        {
            Transform enemyInstantiated = Instantiate(_birdPrefab, transform.position + new Vector3(Random.Range(_leftPositionX, _rightPositionX), transform.position.y + _verticalEnemyOffsetPostionY, transform.position.z), Quaternion.identity).transform;
            Targets targets = Instantiate(_targets, enemyInstantiated.transform.position, Quaternion.identity).GetComponent<Targets>();
            targets.Enemy = enemyInstantiated.GetComponent<Enemy>();
        }

        if (patrollingEnemyProbability == 1)
        {
            Instantiate(_patrolingEnemyPrefab, transform.position + new Vector3(Random.Range(_leftPositionX, _rightPositionX), transform.position.y + _verticalPatrollingEnemyOffsetY, transform.position.z), Quaternion.identity);
        }

        if (staticEnemyProbability == 1)
        {
            Instantiate(_staticEnemyPrefab, transform.position + new Vector3(Random.Range(_leftPositionX, _rightPositionX), transform.position.y + _verticalStaticEnemyOffsetY, transform.position.z), Quaternion.identity);
        }
    }

    private void CreateSlowPlatform()
    {
        int spawnChance = Random.Range(0, _gunProbability);
        
        for (int i = 0; i < _gunCount; i++)
        {
            if (spawnChance == 0)
            {
                Instantiate(_leftGunPrefab, transform.position + new Vector3(_leftPositionX, transform.position.y + _verticalOffsetPositionY, transform.position.z), Quaternion.identity);
                return;
            }
            else if (spawnChance == 1)
            {
                Instantiate(_rightGunPrefab, transform.position + new Vector3(_rightPositionX, transform.position.y + _verticalOffsetPositionY, transform.position.z), Quaternion.identity);
                return;
            }
        }
    }
}
