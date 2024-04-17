using UnityEngine;

public class TimeAcceleration : MonoBehaviour
{
    [SerializeField] private float _timeScale;

    private void Update()
    {
        Time.timeScale = _timeScale;
    }
}
