using UnityEngine;
using System;

public class SaveAchievement : MonoBehaviour
{
    [Tooltip("����� �� ���� ����� ����� ����������, � �� �������� ����������� �����!!!")]
    [SerializeField] private string _achevementKeyName = "ACHIEVEMENT_1"; // ��� ����� ���������� ������� ����� �������� ��� ������ ������ AddAchievement();
    [SerializeField] private string _savedAchievementDateKeyName = "ACHIEVEMNT_1_SAVED_DATE"; // ��� ���������� ���������� ���� ����������� ����������
    [SerializeField] private string _achievedInHours = "ACHIEVED_1_HOURS"; // 1 ��������� �� ����� ����������
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

    public void AddAchievement() // ���� ���������� ��� �� ���� �����, �� ������ �� ��� ����� �������� ����������
    {
        if (_isAchieved == false)
        {
            // ��������� ����������
            PlayerPrefs.SetInt(_achevementKeyName, 1);

            // ��������� ����
            PlayerPrefs.SetString(_savedAchievementDateKeyName, DateTime.Today.ToString());
            Debug.Log(DateTime.Today);

            // ��������� �����
            PlayerPrefs.SetInt(_achievedInHours, DateTime.Now.Hour);
            PlayerPrefs.SetInt(_achievedInMinutes, DateTime.Now.Minute);
        }
    }

    public void AddAchievement(string achievementKeyName, string savedAchievementDateKeyName, string achievedInHours, string achievedInMinutes)
    {
        if (_isAchieved == false)
        {
            // ��������� ����������
            PlayerPrefs.SetInt(achievementKeyName, 1); // ���� ���������� ��� �� ���� �����, �� ������ �� ��� ����� �������� ����������

            // ��������� ����
            PlayerPrefs.SetString(savedAchievementDateKeyName, DateTime.Today.ToString());

            // ��������� �����
            PlayerPrefs.SetInt(achievedInHours, DateTime.Now.Hour);
            PlayerPrefs.SetInt(achievedInMinutes, DateTime.Now.Minute);
        }
    }
}
