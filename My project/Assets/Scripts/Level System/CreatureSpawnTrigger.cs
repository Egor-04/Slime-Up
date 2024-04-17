using UnityEngine;

public class CreatureSpawnTrigger : MonoBehaviour
{
    [Header("Lock Collider")]
    public Transform LockCollider;

    [Header("Creature (Agressive)")]
    [SerializeField] private GameObject _creatureAgressivePrefab;

    [Header("Creature (Non Agressive)")]
    [SerializeField] private GameObject _creaturePrefab;

    [Header("Offset")]
    [Tooltip("“о на сколько метров будет заспавнено существо")]
    [SerializeField] private float _spawnOffsetY;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            int creatureProbability = Random.Range(0, 2);

            if (creatureProbability == 0)
            {
                BonuceUnlocker creatureUnlocker = Instantiate(_creaturePrefab, transform.position + new Vector3(0f, _spawnOffsetY, 0f), Quaternion.identity).GetComponent<BonuceUnlocker>();
                creatureUnlocker.LockCollider = LockCollider;
                Destroy(gameObject);
            }
            else if (creatureProbability == 1)
            {
                AgressiveCreature agressiveCreature = Instantiate(_creatureAgressivePrefab, transform.position + new Vector3(0f, _spawnOffsetY), Quaternion.identity).GetComponent<AgressiveCreature>();
                agressiveCreature.LockCollider = LockCollider;
                Destroy(gameObject);
            }
        }
    }
}
