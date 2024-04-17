using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class WheelFortune : MonoBehaviour
{
    public static WheelFortune StaticWheelFortune;

    [Header("KEY")]
    [SerializeField] private string _keyNameAttempts = "ATTEMPTS_COUNT";

    [Header("Value")]
    [SerializeField] private float _totalAngle;
    [SerializeField] private int _minNumberOfTurns = 40;
    [SerializeField] private int _maxNumberOfTurns = 60;
    [SerializeField] private float _speedRotation = 0.1f;

    [Header("Spin Options")]
    [SerializeField] private int AddLimitSeconds;
    [SerializeField] private int AddLimitMinutes;
    [SerializeField] private int AddLimitHours;
    [SerializeField] private int AddLimitDays;
    [SerializeField] private bool _wheelIsSpiningNow;
    [SerializeField] private bool _canSpinWheelToday;

    [Header("Attempts")]
    [SerializeField] private int _currentAvailableAttempts = 3;

    [Header("What You Win")]
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private string[] _prizeName;
    [SerializeField] private Prize[] _prizes;

    [Header("Balances")]
    public int MoneyBalance;
    public int SlimeFragmentBalance;
    public int SilverStarBalance;
    public int GoldStarBalance;
    public GetSavedKeyValue[] BalanceUpdater;

    [Header("Keys")]
    [SerializeField] private string _moneyKey = "ALL_MONEY";
    [SerializeField] private string _slimeFragmentsKey = "ALL_FRAGMENTS";
    [SerializeField] private string _silverStarsKey = "ALL_SILVER_STARS";
    [SerializeField] private string _goldStarsKey = "ALL_GOLD_STARS";

    [Header("Wheel")]
    [SerializeField] private Transform _fortuneWheel;

    [Header("Spin Limit Timer")]
    [SerializeField] private Image _spinButton;
    [SerializeField] private Sprite _lockedSpinButton;
    [SerializeField] private Sprite _unlockedSpinButton;
    [SerializeField] private SpinLimitTimer _spinLimitTimer;

    private int _numberOfTurns;
    private float _timeInterval;
    [SerializeField] private float _finalAngle;

    [Serializable]
    public class Prize
    {
        [Header("Prize Info")]
        public int ID;
        public int AddCount;
        public string KeyName;

        [Header("Prize Type")]
        public bool IsMoney;
        public bool IsFragments;
        public bool IsGoldStars;
        public bool IsSilverStars;

        public void AddPrize()
        {
            if (IsMoney)
            {
                StaticWheelFortune.MoneyBalance += AddCount;
                PlayerPrefs.SetInt(KeyName, StaticWheelFortune.MoneyBalance);

                for (int i = 0; i < StaticWheelFortune.BalanceUpdater.Length; i++)
                {
                    StaticWheelFortune.BalanceUpdater[i].UpdateBalance();
                }
            }

            if (IsFragments)
            {
                StaticWheelFortune.SlimeFragmentBalance += AddCount;
                PlayerPrefs.SetInt(KeyName, StaticWheelFortune.SlimeFragmentBalance);
                
                for (int i = 0; i < StaticWheelFortune.BalanceUpdater.Length; i++)
                {
                    StaticWheelFortune.BalanceUpdater[i].UpdateBalance();
                }
            }

            if (IsSilverStars)
            {
                StaticWheelFortune.SilverStarBalance += AddCount;
                PlayerPrefs.SetInt(KeyName, StaticWheelFortune.SilverStarBalance);

                for (int i = 0; i < StaticWheelFortune.BalanceUpdater.Length; i++)
                {
                    StaticWheelFortune.BalanceUpdater[i].UpdateBalance();
                }
            }

            if (IsGoldStars)
            {
                StaticWheelFortune.GoldStarBalance += AddCount;
                PlayerPrefs.SetInt(KeyName, StaticWheelFortune.GoldStarBalance);

                for (int i = 0; i < StaticWheelFortune.BalanceUpdater.Length; i++)
                {
                    StaticWheelFortune.BalanceUpdater[i].UpdateBalance();
                }
            }
        }
    }

    private void Awake()
    {
        StaticWheelFortune = this;
    }

    private void Start()
    {
        MoneyBalance = PlayerPrefs.GetInt(_moneyKey);
        SlimeFragmentBalance = PlayerPrefs.GetInt(_slimeFragmentsKey);
        SilverStarBalance = PlayerPrefs.GetInt(_silverStarsKey);
        GoldStarBalance = PlayerPrefs.GetInt(_goldStarsKey);

        if (PlayerPrefs.HasKey(_keyNameAttempts))
        {
            _currentAvailableAttempts = PlayerPrefs.GetInt(_keyNameAttempts);
        }

        _wheelIsSpiningNow = false;
        _totalAngle = 360 / _prizeName.Length;
    }

    private void Update()
    {
        CheckSpinButtonState();
    }

    public void InterruptWheel()
    {
        _wheelIsSpiningNow = false;
    }

    private void CheckSpinButtonState()
    {
        _canSpinWheelToday = _spinLimitTimer.CanSpinToday();

        if (!_canSpinWheelToday)
        {

            _spinButton.sprite = _lockedSpinButton;
        }
        else
        {
            if (_currentAvailableAttempts <= 0)
            {
                _currentAvailableAttempts = 3;
            }

            _spinButton.sprite = _unlockedSpinButton;
        }
    }

    private void AddLimitTime()
    {
        if (_currentAvailableAttempts <= 0)
        {
            _spinLimitTimer.Seconds = AddLimitSeconds;
            _spinLimitTimer.Minutes = AddLimitMinutes;
            _spinLimitTimer.Hours = AddLimitHours;
            _spinLimitTimer.Days = AddLimitDays;
            _spinLimitTimer.SaveTime();
        }
    }

    public void Spin()
    {
        if (!_wheelIsSpiningNow)
        {
            if (_canSpinWheelToday)
            {
                StartCoroutine(SpinWheel());
            }
        }
    }

    private IEnumerator SpinWheel()
    {
        _wheelIsSpiningNow = true;
        
        _numberOfTurns = UnityEngine.Random.Range(_minNumberOfTurns, _maxNumberOfTurns);

        _timeInterval = 0.0001f * Time.deltaTime * 2;

        for (int i = 0; i < _numberOfTurns; i++)
        {
            _fortuneWheel.Rotate(0f, 0f, _totalAngle);

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.2f))
            {
                _timeInterval = 0.5f * Time.deltaTime;
            }

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.5f))
            {
                _timeInterval = 1f * Time.deltaTime;
            }

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.7f))
            {
                _timeInterval = 1.5f * Time.deltaTime;
            }
            
            if (i > Mathf.RoundToInt(_numberOfTurns * 0.8f))
            {
                _timeInterval = 2f * Time.deltaTime;
            }

            if (i > Mathf.RoundToInt(_numberOfTurns * 0.9f))
            {
                _timeInterval = 2.5f * Time.deltaTime;
            }

            yield return new WaitForSeconds(_timeInterval);
        }

        if (Mathf.RoundToInt(_fortuneWheel.rotation.z) % _totalAngle != 0)
        {
            _fortuneWheel.Rotate(0, 0, _totalAngle);
        }

        _finalAngle = Mathf.RoundToInt(_fortuneWheel.eulerAngles.z);

        for (int i = 0; i < _prizeName.Length; i++)
        {
            Debug.Log(_finalAngle + " : " + _totalAngle * i);
            
            if (_finalAngle == i * _totalAngle)
            {
                _winText.text = _prizeName[i];
                _currentAvailableAttempts--;
                PlayerPrefs.SetInt(_keyNameAttempts, _currentAvailableAttempts);
                AddLimitTime();
                GivePrize(i);
            }
        }

        _wheelIsSpiningNow = false;
    }

    private void GivePrize(int i)
    {
        for (int j = 0; j < _prizes.Length; j++)
        {
            if (_prizes[j].ID == i)
            {
                _prizes[j].AddPrize();
            }
        }
    }
}