using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float _speed;
    //[SerializeField] private float _maxConfinePositionY = 3;
    //[SerializeField] private float _minConfinePositionY = -3;
    [SerializeField] private float _timeToChange = 4f;
    [SerializeField] private float _currentTimeToChange = 0f;
    private int _direction;

    private void Update()
    {
        _currentTimeToChange -= Time.deltaTime;
        Patrolling();
    }

    private void Patrolling()
    {
        if (_currentTimeToChange <= 0)
        {
            if (_direction == 0 && _currentTimeToChange <= 0)
            {
                _direction = 1;
                _currentTimeToChange = _timeToChange;
            }
            else
            {
                _direction = 0;
                _currentTimeToChange = _timeToChange;
            }
        }

        if (_direction == 0)
        {
            transform.position += _speed * -transform.up * Time.deltaTime;
        }
        
        if (_direction == 1)
        {
            transform.position += _speed * transform.up * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<SlimePlayer>().GetDamage();
        }
    }
}
