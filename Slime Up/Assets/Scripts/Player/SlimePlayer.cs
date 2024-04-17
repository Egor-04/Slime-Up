using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SlimePlayer : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private int _healthPoints = 4;
    [SerializeField] private float _acelerationSpeed;
    [SerializeField] private float _touchSpeed;

    [Header("Hearts UI")]
    [SerializeField] private Image[] _hearts;

    [Header("Jump Force")]
    [SerializeField] private float _jumpForce;

    [Header("Dead Zone Offset")]
    [SerializeField] private float _offset = -5f;

    [Header("Game Over Panel")]
    [SerializeField] private float _speedAnimation;
    [SerializeField] private Animator _gameOverPanelAnimator;

    [Header("Animator")]
    public Animator Animator;

    [Header("Rigidbody")]
    public Rigidbody2D Rigidbody2D;

    [Header("Current Height")]
    [SerializeField] private TMP_Text _heightText;

    [Header("Controll Modes")]
    [SerializeField] private int _controllMode = 1;
    [SerializeField] private string _keyControll = "CURRENT_CONTROLL_MODE";
    [SerializeField] private SwipeControll _swipeControll;
    [SerializeField] private TouchValue _touchValue;

    [Header("Control Panels")]
    [SerializeField] private GameObject _swipePanel;
    [SerializeField] private GameObject _touchPanel;

    private Transform _deadZone;
    private RecordSystem _recordSystem;
    public static SlimePlayer SlimePlayerStatic;


    private void Start()
    {
        SlimePlayerStatic = this;
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _recordSystem = FindObjectOfType<RecordSystem>();
        _deadZone = GameObject.FindGameObjectWithTag("Dead Zone").transform;
        _controllMode = PlayerPrefs.GetInt(_keyControll);
    }

    private void Update()
    {
        CheckHeight();
        VelocityClamp();
        _recordSystem.GetMaxRecord((int)transform.position.y);

        Animator.SetFloat("Velocity" ,Rigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        _heightText.text = string.Format("{0:0m}", transform.position.y);

        if (_controllMode == 0)
        {
            AccelerationMode();
        }
        else if (_controllMode == 1)
        {
            _swipePanel.SetActive(true);
            SwipeMode();
        }
        else
        {
            _touchPanel.SetActive(true);
            TapMode();
        }
    }

    private void AccelerationMode()
    {
        if (Input.acceleration.x > 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = false;
        }

        if (Input.acceleration.x < 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = true;
        }

        Rigidbody2D.velocity = new Vector2(Input.acceleration.x * _acelerationSpeed, Rigidbody2D.velocity.y);
    }

    private void SwipeMode()
    {
        if (_swipeControll.SwipeValue() > 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = false;
        }

        if (_swipeControll.SwipeValue() < 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = true;
        }

        Rigidbody2D.velocity = new Vector2(_swipeControll.SwipeValue(), Rigidbody2D.velocity.y);
    }

    private void TapMode()
    {
        if (_touchValue.Direction > 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = false;
        }

        if (_touchValue.Direction < 0f)
        {
            SpriteRenderer doodleSprite = GetComponent<SpriteRenderer>();
            doodleSprite.flipX = true;
        }

        Rigidbody2D.velocity = new Vector2(_touchValue.Direction * _touchSpeed, Rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        if (PlayerStates.PlayerStatesScript.IsMoveUpNow)
        {
            Rigidbody2D.velocity = Vector2.up * _jumpForce;
        }
    }

    private void VelocityClamp()
    {
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.y, Mathf.Clamp(Rigidbody2D.velocity.y, -90f, 90f));
    }

    private void CheckHeight()
    {
        if (PlayerStates.PlayerStatesScript.MayDead)
        {
            if (transform.position.y < _deadZone.position.y + _offset)
            {
                PlayerDead();
            }
        }

        if (transform.position.y < -10f)
        {
            PlayerDead();
        }
    }

    public void GetDamage()
    {
        _healthPoints -= 1;

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (_healthPoints <= i)
            {
                _hearts[i].enabled = !true;
            }
        }

        if (_healthPoints <= 0)
        {
            PlayerDead();
        }
    }

    public void PlayerDead()
    {
        _gameOverPanelAnimator.SetBool("Active", true);
    }
}
