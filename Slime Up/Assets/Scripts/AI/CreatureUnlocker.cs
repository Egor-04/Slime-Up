using UnityEngine;

public class CreatureUnlocker : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _speed = 10f;

    [Header("Clamp Position X")]
    [SerializeField] private float _minClampPositionX;
    [SerializeField] private float _maxClampPositionX;

    [Header("Clamp Position Y")]
    [SerializeField] private float _minClampPositionY;
    [SerializeField] private float _maxClampPositionY;

    [Header("Change Direction Timer")]
    [SerializeField] private float _timeChangeRotation = 3f;

    [Header("Rotate Target Point")]
    [SerializeField] private Transform _rotateTargetPoint;
    [SerializeField] private float _rotationZ = 90f;

    [Header("Target Point")]
    [SerializeField] private Transform _targetPoint;

    [Header("Min Distance")]
    [SerializeField] private float _minDistance = 20f;
    
    [Header("Debug")]
    [SerializeField] private float _distance;

    [SerializeField] private Vector3 _spawnPosition;
    private float _currentTime;
    private LevelSystem _levelSystem;
    private Vector3 _currentPosition;

    private void Start()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
        _currentPosition = transform.position;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        ClampPosition();

        MoveToTarget();

        ChangeDirection();
    }

    private void ClampPosition()
    {
        float creatureClampPositionX = Mathf.Clamp(transform.position.x, _minClampPositionX + _currentPosition.x, _maxClampPositionX + _currentPosition.x);
        float creatureClampPositionY = Mathf.Clamp(transform.position.y, _minClampPositionY + _currentPosition.y, _maxClampPositionY + _currentPosition.y);
        transform.position = new Vector3(creatureClampPositionX, creatureClampPositionY, 1f);
    }

    private void MoveToTarget()
    {
        float distance = Vector3.SqrMagnitude(transform.position - _targetPoint.position);
        Vector3 direction = _targetPoint.position - transform.position;
        _distance = distance;

        if (distance <= _minDistance)
        {
            transform.position += direction.normalized * _speed * Time.deltaTime;
        }
    }

    private void ChangeDirection()
    {
        if (_currentTime <= 0f)
        {
            _rotateTargetPoint.eulerAngles += new Vector3(0f, 0f, _rotationZ);
            _currentTime = _timeChangeRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
