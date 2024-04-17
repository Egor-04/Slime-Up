using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Health")]
    public int Health = 100;

    [Header("Damage Force")]
    [SerializeField] private int _damageForce;

    [Header("Min-Max Health")]
    [SerializeField] private int MinHealth = 0;
    [SerializeField] private int MaxHealth = 100;

    [Header("Additional Options")]
    [SerializeField] private float _angle;
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _angularSpeed = 3f;
    [SerializeField] private float _minAttackDistance;
    [SerializeField] private float _maxAttackDistance;
    [SerializeField] private bool _isCircleMovement;

    [Header("Angle")]
    [SerializeField] private bool _directionIsRight;
    [SerializeField] private float _timeChangeAngleDirection = 8f;

    [Header("Shoot Options")]
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotInterval = 8f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform[] _bulletSpawns;

    [Header("Target")]
    [SerializeField] private Transform _startTarget;

    [Header("Player Target")]
    [SerializeField] private Transform _playerTarget;

    private Vector3 _circleDirection;
    private int _directionRotation;
    private float _currentShotInterval;
    private float _currentTimeToChangeAngleDirection;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        _startTarget = GameObject.FindGameObjectWithTag("Start Target").transform;
        _playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Health = Mathf.Clamp(Health, 0, 100);

        FollowTarget();

        if (Health <= 0)
        {
            BossSpawner.StaticBossSpawner.BossIsDefeated = true;
            SaveStarsSystem.StaticSaveStarsSystem.Save();
            Destroy(gameObject);
        }
    }

    private void FollowTarget()
    {
        float distanceToTarget = Mathf.Sqrt(Vector3.SqrMagnitude(transform.position - _startTarget.position));
        Vector3 directionTarget = Vector3.Normalize(_startTarget.position - transform.position) - _circleDirection;

        float distanceToPlayer = Mathf.Sqrt(Vector3.SqrMagnitude(transform.position - _playerTarget.position));
        Vector3 directionPlayer = Vector3.Normalize(_playerTarget.position - transform.position) - _circleDirection;

        RotationAngle();

        if (distanceToPlayer > 2000)
        {
            if (distanceToTarget <= _minAttackDistance && distanceToTarget >= _maxAttackDistance)
            {
                transform.position += _speed * Time.deltaTime * directionTarget;
            }
            else
            {
                Shoot();
                transform.position += _speed * Time.deltaTime * _circleDirection;
            }
        }
        else if (distanceToPlayer < 2000)
        {
            if (distanceToPlayer <= _minAttackDistance && distanceToPlayer >= _maxAttackDistance)
            {
                transform.position += _speed * Time.deltaTime * directionPlayer;
            }
            else
            {
                Shoot();
                transform.position += _speed * Time.deltaTime * _circleDirection;
            }
        }

        CircleMovement();
    }

    private void CircleMovement()
    {
        if (_isCircleMovement)
        {
            float positionX = Mathf.Cos(_angle * _angularSpeed) * _radius;
            float positionY = Mathf.Sin(_angle * _angularSpeed) * _radius;

            _circleDirection = new Vector3(positionX, positionY, 0f);
        }
    }

    private void RotationAngle()
    {
        _currentTimeToChangeAngleDirection -= Time.deltaTime;

        if (_currentTimeToChangeAngleDirection <= 0)
        {
            if (_directionIsRight)
            {
                _directionIsRight = false;
                _directionRotation = 0;
                _currentTimeToChangeAngleDirection = _timeChangeAngleDirection;
            }
            else
            {
                _directionIsRight = true;
                _directionRotation = 1;
                _currentTimeToChangeAngleDirection = _timeChangeAngleDirection;
            }
        }

        if (_directionIsRight)
        {
            if (_angle < 360f)
            {
                _angle += Time.deltaTime;
            }
            else
            {
                _angle = 0f;
            }
        }
        else
        {
            if (_angle > -360f)
            {
                _angle -= Time.deltaTime;
            }
            else
            {
                _angle = 0f;
            }
        }
    }

    private void Shoot()
    {
        _currentShotInterval -= Time.deltaTime;

        if (_currentShotInterval <= 0)
        {
            _currentShotInterval = 0f;

            for (int i = 0; i < _bulletSpawns.Length; i++)
            {
                SpecialBullet specialBullet = Instantiate(_bulletPrefab, _bulletSpawns[i]).GetComponent<SpecialBullet>();
                specialBullet.SetBulletOptions(_speed, _bulletSpawns[i]);
            }

            _currentShotInterval = _shotInterval;
        }
    }

    private void GetDamage()
    {
        Health -= _damageForce;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            GetDamage();
        }
    }
}
