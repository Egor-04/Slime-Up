using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _spawnPoint;

    private void Update()
    {
        transform.Translate(_spawnPoint.up * _speed * Time.deltaTime);
    }

    public void SetBulletOptions(float speed, Transform spawnPoint)
    {
        _speed = speed;
        _spawnPoint = spawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            SlimePlayer player = collision2D.gameObject.GetComponent<SlimePlayer>();
            player.PlayerDead();
        }
    }
}
