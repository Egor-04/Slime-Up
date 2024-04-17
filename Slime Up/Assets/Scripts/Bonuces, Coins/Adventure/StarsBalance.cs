using UnityEngine;

public class StarsBalance : MonoBehaviour
{
    public static StarsBalance StaticStarsBalance;

    [Header("All Stars")]
    public int GoldStarsBalance;
    public int SilverStarsBalance;

    [Header("Keys")]
    [SerializeField] private string _silverStarsKey = "ALL_SILVER_STARS";
    [SerializeField] private string _goldStarsKey = "ALL_GOLD_STARS";

    private void Awake()
    {
        StaticStarsBalance = this;
    }

    private void Start()
    {
        GoldStarsBalance = PlayerPrefs.GetInt(_goldStarsKey);
        SilverStarsBalance = PlayerPrefs.GetInt(_silverStarsKey);
    }

    public void AddGoldStars(int starsCount)
    {
        GoldStarsBalance += starsCount;
    }

    public void AddSilverStars(int starsCount)
    {
        SilverStarsBalance += starsCount;
    }
}
