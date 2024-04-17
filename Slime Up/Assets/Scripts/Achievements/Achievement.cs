using UnityEngine;
using System;
using TMPro;

public class Achievement : MonoBehaviour
{
    [Header("Achievement")]
    [SerializeField] private string _achievementKeyName = "ACHIEVEMENT_1";
    [SerializeField] private string _achievementSavedTimeKeyName = "ACHIEVEMNT_1_SAVED_DATE";
    [SerializeField] private string _achievedInHours = "ACHIEVED_1_HOURS"; // 1 указывает на номер достижени€
    [SerializeField] private string _achievedInMinutes = "ACHIEVED_1_MINUTES";
    [SerializeField] private GameObject _achievedPanel;
    [SerializeField] private TMP_Text _date;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private bool _achieved;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_achievementKeyName))
        {
            _achieved = AchievementIsAchieved();
        }
        else
        {
            PlayerPrefs.SetInt(_achievementKeyName, 0); // ≈сли нет такого сохранени€ значит 0. «начит не получено достижение.
        }

        if (_achieved)
        {
            _achievedPanel.SetActive(true);

            _date.text = PlayerPrefs.GetString(_achievementSavedTimeKeyName);
            _time.text = PlayerPrefs.GetInt(_achievedInHours).ToString("00") + ":" + PlayerPrefs.GetInt(_achievedInMinutes).ToString("00");
        }
        else
        {
            _achievedPanel.SetActive(false);

            _date.text = null;
        }
    }

    private bool AchievementIsAchieved()
    {
        if (PlayerPrefs.GetInt(_achievementKeyName) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
