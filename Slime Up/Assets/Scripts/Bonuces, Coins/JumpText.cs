using UnityEngine;

public class JumpText : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _speed;

    [Header("Time to Destroy")]
    [SerializeField] private float _timeDestroy = 5f;

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
        Destroy(gameObject, _timeDestroy);
    }
}
