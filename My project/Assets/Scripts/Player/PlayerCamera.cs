using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;

    private void Update()
    {
        if (PlayerStates.PlayerStatesScript.IsMoveUpNow)
        {
            if (_playerPosition.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, _playerPosition.position.y, transform.position.z);
            }
        }
        else
        {
            if (_playerPosition.position.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, _playerPosition.position.y, transform.position.z);
            }
        }
    }
}
