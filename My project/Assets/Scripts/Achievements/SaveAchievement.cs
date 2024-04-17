using UnityEngine;
using System;

public class SaveAchievement : MonoBehaviour
{
    [Tooltip("УКАЖИ ВО ВСЕХ ПОЛЯХ НОМЕР ДОСТИЖЕНИЯ, А ТО РАБОТАТЬ НЕПРАВИЛЬНО БУДЕТ!!!")]
    [SerializeField] private string _achevementKeyName = "ACHIEVEMENT_1"; // Имя ключа достижения которое будет получено при вызове метода AddAchievement();
    [SerializeField] private string _savedAchievementDateKeyName = "ACHIEVEMNT_1_SAVED_DATE"; // Так называется сохранение даты полученного достижения
    [SerializeField] private string _achievedInHours = "ACHIEVED_1_HOURS"; // 1 указывает на номер достижения
    [SerializeField] private string _achievedInMinutes = "ACHIEVED_1_MINUTES";
    [SerializeField] private bool _isAchieved;

    private void Start()
    {
        _isAchieved = IsAchieved();
    }

    private bool IsAchieved()
    {
        if (PlayerPrefs.GetInt(_achevementKeyName) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddAchievement() // Если вызывается где то этот метод, то значит за это будет получено достижение
    {
        if (_isAchieved == false)
        {
            // Сохраняем достижение
            PlayerPrefs.SetInt(_achevementKeyName, 1);

            // Сохраняем дату
            PlayerPrefs.SetString(_savedAchievementDateKeyName, DateTime.Today.ToString());
            Debug.Log(DateTime.Today);

            // Сохраняем время
            PlayerPrefs.SetInt(_achievedInHours, DateTime.Now.Hour);
            PlayerPrefs.SetInt(_achievedInMinutes, DateTime.Now.Minute);
        }
    }

    public void AddAchievement(string achievementKeyName, string savedAchievementDateKeyName, string achievedInHours, string achievedInMinutes)
    {
        if (_isAchieved == false)
        {
            // Сохраняем достижение
            PlayerPrefs.SetInt(achievementKeyName, 1); // Если вызывается где то этот метод, то значит за это будет получено достижение

            // Сохраняем дату
            PlayerPrefs.SetString(savedAchievementDateKeyName, DateTime.Today.ToString());

            // Сохраняем время
            PlayerPrefs.SetInt(achievedInHours, DateTime.Now.Hour);
            PlayerPrefs.SetInt(achievedInMinutes, DateTime.Now.Minute);
        }
    }
}
