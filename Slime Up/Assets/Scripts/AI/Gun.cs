using UnityEngine;


public class Gun : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private GameObject _bullet;

    [Header("Animator")]
    [SerializeField] private Animator _animator;

    [Header("Time")]
    [SerializeField] private float _shotInterval;

    private float _currentShotInterval;

    private void Update()
    {
        _currentShotInterval -= Time.deltaTime;

        Shot();
    }

    private void Shot()
    {
        if (_currentShotInterval <= 0f)
        {
            _currentShotInterval = 0f;
            _animator.SetTrigger("Shot");
            Instantiate(_bullet, transform.position, Quaternion.identity);
            _currentShotInterval = _shotInterval;
        }
    }
}
