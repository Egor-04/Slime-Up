using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    [Header("Time to Destroy")]
    [SerializeField] private float _timeDestroy = 1f;

    [Header("Animator")]
    [SerializeField] private Animator _animator;

    private float _currentTimeToParticles;
    private bool _destroyNow;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _currentTimeToParticles -= Time.deltaTime;
    }

    //private void OnTriggerEnter2D(Collider2D collider2D)
    //{
    //    if (collider2D.gameObject.CompareTag("Dead Zone"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Player"))
        {
            if (PlayerStates.PlayerStatesScript.IsMoveUpNow)
            {
                if (collision2D.relativeVelocity.y <= 0f)
                {
                    SlimePlayer.SlimePlayerStatic.Animator.SetTrigger("Falled");
                }
            }

            if (!_destroyNow)
            {
                _destroyNow = true;
            }

            _animator.SetBool("Quake", true);

            Destroy(gameObject, _timeDestroy);
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
}
