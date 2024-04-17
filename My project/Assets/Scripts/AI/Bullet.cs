using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Speed")]
    [SerializeField] private float _bulletSpeed;

    private void Update()
    {
        transform.Translate(-Vector3.up * _bulletSpeed * Time.deltaTime);
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