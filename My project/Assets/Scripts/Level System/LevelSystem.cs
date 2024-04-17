using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private bool _saveData;

    [Header("Level Count")]
    public int MaxLevelCount;
    public int CurrentLevelCount;
    [SerializeField] private int _nextLevelCount;

    [Header("Level Count Text")]
    public TMP_Text MaxRecordLevelText;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;

    private SaveSystem _saveSystem;

    public void Start()
    {
        CurrentLevelCount = 1;
        _currentLevelText.text = CurrentLevelCount.ToString();
        _saveSystem = FindObjectOfType<SaveSystem>();
    }

    private void Update()
    {
        MaxRecordLevelText.text = MaxLevelCount.ToString();

        CheckLevel();
    }

    public void CheckLevel()
    {
        if (CurrentLevelCount > MaxLevelCount)
        {
            MaxLevelCount = CurrentLevelCount;

            if (_saveData)
            {
                _saveSystem.Save();
            }
        }
    }

    public void AddLevel()
    {
        CurrentLevelCount += 1;
        _currentLevelText.text = CurrentLevelCount.ToString();

        _nextLevelCount = CurrentLevelCount;
        _nextLevelCount += 1;

        _nextLevelText.text = "Level " + _nextLevelCount.ToString();   
    }
}
