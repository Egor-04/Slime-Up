using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Jump Force")]
    [SerializeField] public float _jumpForce;
    [SerializeField] private bool _isSuperJump = false;

    public static Platform PlatformScript;

    private void Start()
    {
        PlatformScript = this;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.relativeVelocity.y <= 0f)
        {
            if (_isSuperJump)
            {
                SlimePlayer.SlimePlayerStatic.Rigidbody2D.velocity = Vector2.up * _jumpForce;
            }

            SlimePlayer.SlimePlayerStatic.Animator.SetTrigger("Falled");
        }
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (PlayerStates.PlayerStatesScript.IsMoveUpNow)
        {
            if (collision2D.relativeVelocity.y <= 0f)
            {
                SlimePlayer.SlimePlayerStatic.Animator.SetTrigger("Falled");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            SlimePlayer.SlimePlayerStatic.Animator.SetTrigger("Jump");
        }
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Destroy Platform"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        //if (collider2D.gameObject.CompareTag("Dead Zone"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
