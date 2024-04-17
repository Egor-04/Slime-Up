using UnityEngine;

public enum Direction { Right, Left }
public class GunBullet : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _bulletForce = 10f;

    [Header("Direction")]
    [SerializeField] private Direction _direction;

    private void Update()
    {
        if (_direction == Direction.Left)
        {
            transform.Translate(-Vector2.right * _bulletForce * Time.deltaTime);
        }
        else if (_direction == Direction.Right)
        {
            transform.Translate(Vector2.right * _bulletForce * Time.deltaTime);
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
        }
    }
}
