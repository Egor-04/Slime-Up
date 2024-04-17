using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float _timeDestroy = 10f;

    private void Update()
    {
        Destroy(gameObject, _timeDestroy);
    }
}
