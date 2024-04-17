using UnityEngine;

public class OneSpawnBonuceTrigger : MonoBehaviour
{
    [Header("Lock Collider")]
    [SerializeField] private Transform _lockCollider;

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
                    CreatureSpawnTrigger creatureSpawnTrigger = Instantiate(_bonuceCreatureUnlockerPrefab, transform.position + new Vector3(transform.position.x, _minOffsetPositionY, 0f), Quaternion.identity).GetComponent<CreatureSpawnTrigger>();
                    creatureSpawnTrigger.LockCollider = _lockCollider;
                }
                else if (bonuceUnlockerProbability == 1)
                {
                    CreatureSpawnTrigger creatureSpawnTrigger = Instantiate(_bonuceCreatureUnlockerPrefab, transform.position + new Vector3(transform.position.x, _maxOffsetPositionY, 0f), Quaternion.identity).GetComponent<CreatureSpawnTrigger>();
                    creatureSpawnTrigger.LockCollider = _lockCollider;
                }
            }
            else
            {
                int bonuceUnlockerProbability = Random.Range(0, 2);

                if (bonuceUnlockerProbability == 0)
                {
                    BonuceUnlocker bonuceUnlocker = Instantiate(_bonuceCrystallUnlockerPrefab, transform.position + new Vector3(transform.position.x, _minOffsetPositionY, 0f), Quaternion.identity).GetComponent<BonuceUnlocker>();
                    bonuceUnlocker.LockCollider = _lockCollider;
                }
                else if (bonuceUnlockerProbability == 1)
                {
                    BonuceUnlocker bonuceUnlocker = Instantiate(_bonuceCrystallUnlockerPrefab, transform.position + new Vector3(transform.position.x, _maxOffsetPositionY, 0f), Quaternion.identity).GetComponent<BonuceUnlocker>();
                    bonuceUnlocker.LockCollider = _lockCollider;
                }
            }

            Destroy(gameObject);
        }
    }
}
