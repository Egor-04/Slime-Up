using UnityEngine;

public class HidingPlatform : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void EyeOpen()
    {
        _boxCollider2D.isTrigger = false;
        _spriteRenderer.material.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1f);
    }

    public void EyeClose()
    {
        _boxCollider2D.isTrigger = true;
        _spriteRenderer.material.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.relativeVelocity.y <= 0f)
        {
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
        if (collider2D.gameObject.CompareTag("Dead Zone"))
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