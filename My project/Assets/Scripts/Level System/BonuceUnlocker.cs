using UnityEngine;

public class BonuceUnlocker : MonoBehaviour
{
    [Header("Tag")]
    [SerializeField] private string _tagCollider = "Lock Zone";

    [Header("Type of Lock Collider")]
    [SerializeField] private bool _findLockCollider = true;
    [SerializeField] private bool _destroyCollider;
    
    [Header("Spawn Offset")]
    [Tooltip("“о на сколько передвинетс€ блокировочна€ зона")]
    [SerializeField] private float _moveOffset = 200f;

    [Header("Colliders")]
    public Transform LockCollider;

    private LevelSystem _levelSystem;

    private void Start()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();

        if (_findLockCollider)
        {
            LockCollider = GameObject.FindGameObjectWithTag(_tagCollider).transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            _levelSystem.AddLevel();
            
            if (LockCollider && !_destroyCollider)
            {
                LockCollider.position += new Vector3(0f, _moveOffset, 0f);
            }

            if (LockCollider && _destroyCollider)
            {
                Destroy(LockCollider.gameObject);
            }
            
            Destroy(gameObject);
        }
    }
}