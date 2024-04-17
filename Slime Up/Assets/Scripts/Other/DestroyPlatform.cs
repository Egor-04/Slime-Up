using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Platform"))
        {
            Destroy(collider2D.gameObject);
        }
    }
}
