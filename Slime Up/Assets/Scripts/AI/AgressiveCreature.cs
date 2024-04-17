using UnityEngine;

public class AgressiveCreature : MonoBehaviour
{
    [Header("Lock Zone")]
    [SerializeField] private string _tagCollider = "Lock Zone";
    [SerializeField] private bool _findLockCollider = true;
    [SerializeField] private bool _destroyCollider;

    [Header("Speed")]
    [SerializeField] private float _speed = 50f;

    [Header("Clamp Position X")]
    [SerializeField] private float _minClampPositionX;
    [SerializeField] private float _maxClampPositionX;

    [Header("Clamp Position Y")]
    [SerializeField] private float _minClampPositionY;
    [SerializeField] private float _maxClampPositionY;

    [Header("Shot Interval")]
    [SerializeField] private float _shotInterval = 2f;
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Time to destroy")]
    [SerializeField] private float _timeDestroy = 20f;

    [Header("Player Target")]
    [SerializeField] private Transform _playerTarget;

    [Header("Spawn Offset")]
    [Tooltip("“о на сколько передвинетс€ блокировочна€ зона")]
    [SerializeField] private float _moveOffset = 200f;

    [Header("Colliders")]
    public Transform LockCollider;

    [Header("Min Distance")]
    [SerializeField] private float _minDistance = 20f;

    [Header("Debug")]
    [SerializeField] private float _distance;
    [SerializeField] private Vector3 _spawnPosition;

    private float _currentShotIntervalTime;
    private float _currentTimeDestroy;
    private LevelSystem _levelSystem;
    private Vector3 _currentPosition;

    private void Start()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _currentPosition = transform.position;
        _currentTimeDestroy += _timeDestroy;
        _currentShotIntervalTime += _shotInterval;
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

        if (_findLockCollider)
        {
            LockCollider = GameObject.FindGameObjectWithTag(_tagCollider).transform;
        }
    }

    private void Update()
    {
        _currentTimeDestroy -= Time.deltaTime;
        _currentShotIntervalTime -= Time.deltaTime;

        Shooting();

        MoveToTarget();

        TimeToDestroy();
    }

    private void Shooting()
    {
        if (_currentShotIntervalTime <= 0f)
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _currentShotIntervalTime += _shotInterval;
        }
    }

    private void MoveToTarget()
    {
        float distance = Vector3.SqrMagnitude(transform.position - _playerTarget.position);
        Vector3 direction = _playerTarget.position - transform.position;
        _distance = distance;

        if (distance >= _minDistance)
        {
            transform.position += direction.normalized * _speed * Time.deltaTime;
        }
    }

    private void TimeToDestroy()
    {
        if (_currentTimeDestroy <= 0f)
        {
            _levelSystem.AddLevel();

            if (LockCollider && !_destroyCollider)
            {
                LockCollider.position += new Vector3(0f, _moveOffset, 0f);
            }
            else if (LockCollider && _destroyCollider)
            {
                Destroy(LockCollider.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
