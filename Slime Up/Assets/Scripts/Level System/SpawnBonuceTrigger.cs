using UnityEngine;

public class SpawnBonuceTrigger : MonoBehaviour
{
    [Tooltip("То на сколько передвинется триггер после входа")]
    [SerializeField] private float _movePositionOffset = 50f;

    [Header("Bonuce Unlocker")]
    [SerializeField] private GameObject _bonuceCreatureUnlockerPrefab;
    [SerializeField] private GameObject _bonuceCrystallUnlockerPrefab;

    [Header("Offset Y")]
    [SerializeField] private float _minOffsetPositionY;
    [SerializeField] private float _maxOffsetPositionY;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            int typeBonuceUnlockerProbability = Random.Range(0, 2);

            if (typeBonuceUnlockerProbability == 0)
            {
                int bonuceUnlockerProbability = Random.Range(0, 2);
                
                if (bonuceUnlockerProbability == 0)
                {
                    Instantiate(_bonuceCreatureUnlockerPrefab, transform.position + new Vector3(transform.position.x, _minOffsetPositionY, 0f), Quaternion.identity);
                }
                else if (bonuceUnlockerProbability == 1)
                {
                    Instantiate(_bonuceCreatureUnlockerPrefab, transform.position + new Vector3(transform.position.x, _maxOffsetPositionY, 0f), Quaternion.identity);
                }
            }
            else
            {
                int bonuceUnlockerProbability = Random.Range(0, 2);

                if (bonuceUnlockerProbability == 0)
                {
                    Instantiate(_bonuceCrystallUnlockerPrefab, transform.position + new Vector3(transform.position.x, _minOffsetPositionY, 0f), Quaternion.identity);
                }
                else if (bonuceUnlockerProbability == 1)
                {
                    Instantiate(_bonuceCrystallUnlockerPrefab, transform.position + new Vector3(transform.position.x, _maxOffsetPositionY, 0f), Quaternion.identity);
                }
            }

            transform.position += new Vector3(0f, _movePositionOffset, 0f);
        }
    }
}