using UnityEngine;
using System;
using TMPro;

public enum TimerType { Plus, Minus }
public class SpinLimitTimer : MonoBehaviour
{
    [Header("Timer Type")]
    [SerializeField] private TimerType _timerType;

    [Header("TEST KEY")]
    [SerializeField] private string _keyNameTime = "LAST_TIME";

    [Header("Key Timer of Fortune Wheel")]
    [SerializeField] private string _keyNameSeconds = "LAST_SECONDS";
    [SerializeField] private string _keyNameMinutes = "LAST_MINUTES";
    [SerializeField] private string _keyNameHours = "LAST_HOURS";
    [SerializeField] private string _keyNameDays = "LAST_DAYS";

    [Header("Text Time")]
    [SerializeField] private TMP_Text _textSeconds;
    [SerializeField] private TMP_Text _textMinutes;
    [SerializeField] private TMP_Text _textHours;
    [SerializeField] private TMP_Text _textDays;

    [Header("Spin Limit Time")]
    public float Seconds;
    public int Minutes;
    public int Hours;
    public int Days;

    [Header("Last Exit Time")]
    public float LastExitSeconds;
    public int LastExitMinutes;
    public int LastExitHours;
    public int LastExitDays;

    private TimeSpan _timeSpan;

    private void Awake()
    {
        TimeAfterQuit();
    }

    private void Start()
    {
        Time.timeScale = 1;

        _textMinutes.text = Minutes.ToString("00");
        _textHours.text = Hours.ToString("00");
        _textDays.text = Days.ToString("00");
    }

    private void Update()
    {
        SaveTime();

        if (_timerType == TimerType.Plus)
        {
            TimerPlus();
        }
        else
        {
            TimerMinus();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveTime();
        }
        else
        {
            TimeAfterQuit();
        }
    }

    //private void OnApplicationQuit()// Нужно только на пк
    //{
    //    SaveTime();
    //}

    private void TimeAfterQuit()
    {
        // Получаем время отсутствия, показывает при входе в игру
        if (PlayerPrefs.HasKey(_keyNameTime))
        {
            _timeSpan = DateTime.UtcNow - DateTime.Parse(PlayerPrefs.GetString(_keyNameTime));

            LastExitSeconds = _timeSpan.Seconds;
            LastExitMinutes = _timeSpan.Minutes;
            LastExitHours = _timeSpan.Hours;
            LastExitDays = _timeSpan.Days;
            Debug.Log(string.Format("{0} : {1} : {2} : {3}", _timeSpan.Seconds, _timeSpan.Minutes, _timeSpan.Hours, _timeSpan.Days));
        }

        // Сохраненное время по гринвичу перед выходом из игры
        PlayerPrefs.SetString(_keyNameTime, DateTime.UtcNow.ToString());

        LoadTime();
        TimeSubstraction(_timeSpan.Seconds, _timeSpan.Minutes, _timeSpan.Hours, _timeSpan.Days);
    }

    public void SaveTime()// Сохраненное время таймера колеса фортуны, после выхода из приложения
    {
        Debug.Log("SAVE LAST TIME OF FORTUNE WHEEL");
        PlayerPrefs.SetFloat(_keyNameSeconds, Seconds);
        PlayerPrefs.SetInt(_keyNameMinutes, Minutes);
        PlayerPrefs.SetInt(_keyNameHours, Hours);
        PlayerPrefs.SetInt(_keyNameDays, Days);
    }

    private void LoadTime()
    {
        Debug.Log("LOAD LAST TIME OF FORTUNE WHEEL");
        Seconds = PlayerPrefs.GetFloat(_keyNameSeconds);
        Minutes = PlayerPrefs.GetInt(_keyNameMinutes);
        Hours = PlayerPrefs.GetInt(_keyNameHours);
        Days = PlayerPrefs.GetInt(_keyNameDays);
    }

    private void TimeSubstraction(float seconds, int minutes, int hours, int days)
    {
        Debug.Log("SUBSTRACTION");
        Seconds -= seconds;
        Minutes -= minutes;
        Hours -= hours;
        Days -= days;
        SaveTime();
    }

    public bool CanSpinToday()
    {
        if (Days <= 0 && Hours <= 0 && Minutes <= 0 && Seconds <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TimerMinus()
    {
        Seconds = Mathf.Clamp(Seconds, 0, 60);
        Minutes = Mathf.Clamp(Minutes, 0, 60);
        Hours = Mathf.Clamp(Hours, 0, 24);
        Days = Mathf.Clamp(Days, 0, 24);

        Seconds -= Time.deltaTime * 1;
        _textSeconds.text = Seconds.ToString("00");
        // Если надо проверить идет ли таймер на пк, то здесь нужно прописать SaveTime();


        if (Minutes > 0 && Seconds <= 0)
        {
            Seconds = 59;
            Minutes -= 1;
            CheckTimeLimit();
            _textMinutes.text = Minutes.ToString("00");
        }
        else
        {
            _textMinutes.text = Minutes.ToString("00");
        }

        if (Hours > 0 && Minutes <= 0)
        {
            Minutes = 59;
            Hours -= 1;
            CheckTimeLimit();
            _textHours.text = Hours.ToString("00");
        }
        else
        {
            _textHours.text = Hours.ToString("00");
        }

        if (Days > 0 && Hours <= 0)
        {
            Hours = 59;
            Days -= 1;
            CheckTimeLimit();
            _textDays.text = Days.ToString("00");
        }
    }

    private void CheckTimeLimit()
    {
        if (Seconds <= 0)
        {
            Seconds = 0;
        }

        if (Minutes <= 0)
        {
            Minutes = 0;
        }

        if (Hours <= 0)
        {
            Hours = 0;
        }

        if (Days <= 0)
        {
            Days = 0;
        }
    }

    private void TimerPlus()
    {
        Seconds += Time.deltaTime * 1;
        _textSeconds.text = Seconds.ToString("00");

        if (Seconds >= 60)
        {
            Minutes += 1;
            Seconds = 0;
            _textMinutes.text = Minutes.ToString("00");
            return;
        }
        else
        {
            _textMinutes.text = Minutes.ToString("00");
        }

        if (Minutes >= 60)
        {
            Hours += 1;
            Minutes = 0;
            _textHours.text = Hours.ToString("00");
            return;
        }
        else
        {
            _textHours.text = Hours.ToString("00");
        }

        if (Hours > 23)
        {
            Days += 1;
            Hours = 0;
            _textDays.text = Days.ToString("00");
            return;
        }
        else
        {
            _textDays.text = Days.ToString("00");
        }
    }
}