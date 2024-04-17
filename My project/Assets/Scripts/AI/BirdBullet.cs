using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _speed;

    [Header("Target")]
    [SerializeField] private Vector3 _targetDirection;

    private void Start()
    {
        _targetDirection = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        if (_targetDirection != null)
        {
            float distance = Vector3.SqrMagnitude(transform.position - _targetDirection);
            Vector3 direction = _targetDirection - transform.position;
            transform.position += direction.normalized * _speed * Time.deltaTime;

            if (distance <= 1f)
            {
                Destroy(gameObject);
            }
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
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player"))
        {
            SlimePlayer.SlimePlayerStatic.GetDamage();
            Destroy(gameObject);
        }
    }
}
