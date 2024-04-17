using UnityEngine;

public class SpikedPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            SlimePlayer.SlimePlayerStatic.GetDamage();
        }
    }
}
