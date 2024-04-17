using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates PlayerStatesScript;

    [Header("States")]
    public bool MayDead;
    public bool ShieldActive = false;
    public bool JetpackActive = false;

    [Header("Movement States")]
    public bool IsMoveUpNow = true;
    public GameObject ArrowUp;
    public GameObject ArrowDown;

    [Header("Shield")]
    [SerializeField] private GameObject _shield;

    [Header("Jetpack")]
    [SerializeField] private GameObject _jetpack;

    [Header("Jetpack Force")]
    [SerializeField] private float _jetpackForce;
    
    [Header("Current Effect Timers")]
    [SerializeField] private float _currentTimeShieldEffect;
    [SerializeField] private float _currentTimeJetpackEffect;

    private void Start()
    {
        PlayerStatesScript = GetComponent<PlayerStates>();
    }

    private void Update()
    {
        Shield();
        Jetpack();
    }

    public void AddShieldEffect(float shieldTime)
    {
        _currentTimeShieldEffect = shieldTime;
    }

    public void AddJetpackEffect(float jetpackEffectTime, float jetpackForce)
    {
        _jetpackForce = jetpackForce;
        _currentTimeJetpackEffect = jetpackEffectTime;
    }

    public void EnableMovementUp()
    {
        if (!IsMoveUpNow)
        {
            IsMoveUpNow = true;
            ArrowUp.SetActive(true);
            ArrowDown.SetActive(false);
            MayDead = true;
        }
    }

    public void EnableMovementDown()
    {
        if (IsMoveUpNow)
        {
            IsMoveUpNow = false;
            ArrowUp.SetActive(false);
            ArrowDown.SetActive(true);
            MayDead = false;
        }
    }

    private void Shield()
    {
        if (ShieldActive)
        {
            _currentTimeShieldEffect -= Time.deltaTime;

            if (_currentTimeShieldEffect <= 0f)
            {
                _currentTimeShieldEffect = 0f;
                _shield.SetActive(false);
                ShieldActive = false;
            }
            else
            {
                _shield.SetActive(true);
            }
        }
    }

    private void Jetpack()
    {
        if (JetpackActive)
        {
            _currentTimeJetpackEffect -= Time.deltaTime;

            if (_currentTimeJetpackEffect <= 0f)
            {
                _currentTimeJetpackEffect = 0f;
                SlimePlayer.SlimePlayerStatic.Rigidbody2D.isKinematic = false;
                _jetpack.SetActive(false);
                JetpackActive = false;
            }
            else
            {
                SlimePlayer.SlimePlayerStatic.Rigidbody2D.isKinematic = true;
                SlimePlayer.SlimePlayerStatic.Rigidbody2D.velocity += Vector2.up * _jetpackForce * Time.deltaTime;
                _jetpack.SetActive(true);
            }
        }
    }
}
