using UnityEngine;

public class AchievementTrigger : MonoBehaviour
{
    [SerializeField] private SaveAchievement _saveAchievement;

    private void Start()
    {
        _saveAchievement = GetComponent<SaveAchievement>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            _saveAchievement.AddAchievement();
        }
    }
}
