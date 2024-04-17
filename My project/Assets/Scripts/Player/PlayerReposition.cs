using UnityEngine;

public class PlayerReposition : MonoBehaviour
{
    [SerializeField] private Transform _pointReposition;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Vector3 playerRePosition = _pointReposition.position;
            collider2D.transform.position = playerRePosition;
        }
    }
}
