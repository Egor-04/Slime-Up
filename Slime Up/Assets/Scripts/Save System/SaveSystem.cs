using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private MoneySystem _moneySystem;
    private RecordSystem _recordSystem;
    private LevelSystem _levelSystem;

    private void Start()
    {
        Time.timeScale = 1f;
        _moneySystem = FindObjectOfType<MoneySystem>();
        _recordSystem = FindObjectOfType<RecordSystem>();
        _levelSystem = FindObjectOfType<LevelSystem>();
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("ALL_MONEY", _moneySystem.AllMoney);
        //PlayerPrefs.SetInt("MAX_LEVEL", _levelSystem.MaxLevelCount);
        PlayerPrefs.SetInt("MAX_HEIGHT_RECORD", _recordSystem.MaxRecord);
        Debug.Log("DATA SAVED");
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("ALL_MONEY"))
        {
            _moneySystem.AllMoney = PlayerPrefs.GetInt("ALL_MONEY");
        }

        if (PlayerPrefs.HasKey("MAX_HEIGHT_RECORD"))
        {
            _recordSystem.MaxRecord = PlayerPrefs.GetInt("MAX_HEIGHT_RECORD");
        }

        //if (PlayerPrefs.HasKey("MAX_LEVEL"))
        //{
        //    _levelSystem.MaxLevelCount = PlayerPrefs.GetInt("MAX_LEVEL");
        //}

        Debug.Log("DATA LOADED");
    }

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
    
    public void QuitAndSave()
    {
        Save();
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
