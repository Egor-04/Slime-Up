using UnityEngine;

public class SaveStarsSystem : MonoBehaviour
{
    public static SaveStarsSystem StaticSaveStarsSystem;
    [SerializeField] private string GoldStarsKeyName = "ALL_GOLD_STARS";
    [SerializeField] private string SilverStarsKeyName = "ALL_SILVER_STARS";

    private void Start()
    {
        Time.timeScale = 1f;
        StaticSaveStarsSystem = this;
        Load();
    }

    public void Save()
    {
        if (BossSpawner.StaticBossSpawner.BossIsDefeated)
        {
            if (StarsBalance.StaticStarsBalance.GoldStarsBalance != 0 && StarsBalance.StaticStarsBalance.SilverStarsBalance != 0)
            {
                PlayerPrefs.SetInt(GoldStarsKeyName, StarsBalance.StaticStarsBalance.GoldStarsBalance);
                PlayerPrefs.SetInt(SilverStarsKeyName, StarsBalance.StaticStarsBalance.SilverStarsBalance);
            }
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(GoldStarsKeyName) && PlayerPrefs.HasKey(SilverStarsKeyName))
        {
            StarsBalance.StaticStarsBalance.GoldStarsBalance = PlayerPrefs.GetInt(GoldStarsKeyName);
            StarsBalance.StaticStarsBalance.SilverStarsBalance = PlayerPrefs.GetInt(SilverStarsKeyName);
            Debug.Log("STARS DATA LOADED");
        }
    }
}
