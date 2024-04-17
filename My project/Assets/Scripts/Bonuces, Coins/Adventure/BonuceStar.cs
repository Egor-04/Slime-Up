using UnityEngine;

public enum StarType {Gold, Silver}
public class BonuceStar : MonoBehaviour
{
    [Header("Star Type")]
    [SerializeField] private StarType _starType;

    [Header("Stars Count")]
    [SerializeField] private int _starsCount = 1;

    private void Awake()
    {
        StarsSpawner.StaticStarsSpawner.AddStar(this);
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            if (_starType == StarType.Gold)
            {
                StarsBalance.StaticStarsBalance.AddGoldStars(_starsCount);
                StarsSpawner.StaticStarsSpawner.Remove(this);
                SaveAgain();
                Destroy(gameObject);
            }
            else
            {
                StarsBalance.StaticStarsBalance.AddSilverStars(_starsCount);
                StarsSpawner.StaticStarsSpawner.Remove(this);
                SaveAgain();
                Destroy(gameObject);
            }
        }
    }

    private void SaveAgain()
    {
        if (BossSpawner.StaticBossSpawner.BossIsDefeated)
        {
            SaveStarsSystem.StaticSaveStarsSystem.Save();
        }
    }
}
