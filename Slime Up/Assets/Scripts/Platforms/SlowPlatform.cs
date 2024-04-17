using UnityEngine;

public class SlowPlatform : MonoBehaviour
{
    [SerializeField] private float _slowSpeed = -0.1f;
    [SerializeField] private float _lerpSpeed = 0.1f;

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            SlimePlayer doodlePlayer = collider2D.gameObject.GetComponent<SlimePlayer>();
            doodlePlayer.Rigidbody2D.velocity = new Vector2(doodlePlayer.Rigidbody2D.velocity.x, Mathf.Lerp(doodlePlayer.Rigidbody2D.velocity.y, doodlePlayer.Rigidbody2D.velocity.y * _slowSpeed, _lerpSpeed));
        }
    }
}
