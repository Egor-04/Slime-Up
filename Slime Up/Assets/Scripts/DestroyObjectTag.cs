using UnityEngine;

public class DestroyObjectTag : MonoBehaviour
{
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
}
