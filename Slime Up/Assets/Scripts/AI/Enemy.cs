using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float _speed = 5f;

    [Header("Bullet Speed")]
    [SerializeField] private float _bulletSpeed = 6f;

    [Header("Shot Interval")]
    [SerializeField] private float _shotInterval = 2f;

    [Header("Enemy Sprite Renderer")]
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Bullet Prefab")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Bullet Spawn")]
    [SerializeField] private Transform _bulletSpawn;
    
    [Header("Patrol Points")]
    [SerializeField] private Transform[] _targets;

    [Header("Enemy State")]
    [SerializeField] private bool _canShoot = true;


    private float _currentShotInterval;
    private int _currentPointNumber;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _currentShotInterval -= Time.deltaTime;

        Vector3 direction = _targets[_currentPointNumber].position - transform.position;
        float distance = direction.sqrMagnitude;

        if (direction.x > 0 )
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        Shot();
        MoveToPoint(distance, direction);
    }

    private void Shot()
    {
        if (_canShoot)
        {
            if (_currentShotInterval <= 0f)
            {
                _currentShotInterval = 0f;

                Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.identity);
                _currentShotInterval = _shotInterval;
            }
        }
    }

    private void MoveToPoint(float distance, Vector3 direction)
    {
        transform.position += direction.normalized * _speed * Time.deltaTime;

        if (distance <= 5f)
        {
            FindPoint();
        }
    }

    public void GetPatrolTargets(Transform targetFirst, Transform targetSecond)
    {
        _targets[0] = targetFirst;
        _targets[1] = targetSecond;
    }

    private void FindPoint()
    {
        for (int i = 0; i < _targets.Length; i++)
        {
            _currentPointNumber = Random.Range(0, _targets.Length);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player"))
        {
            SlimePlayer.SlimePlayerStatic.GetDamage();
            //SlimePlayer.SlimePlayerStatic.PlayerDead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

        if (collider2D.gameObject.CompareTag("Jetpack"))
        {
            Destroy(gameObject);
        }

        //if (collider2D.CompareTag("Dead Zone"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
