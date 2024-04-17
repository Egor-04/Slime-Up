using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static BossSpawner StaticBossSpawner;

    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Transform _spawnPoint;

    public bool BossIsDefeated = false;
    
    [Tooltip("Если 0 значит босс должен заспавниться, если 1 то не должен")] 
    public int CurrentState;
    [SerializeField] private string KeyName = "BOSS_SPAWN_STATE";

    private void Awake()
    {
        StaticBossSpawner = this;
    }

    private void Start()
    {
        CurrentState = PlayerPrefs.GetInt(KeyName);

        if (!BossIsDefeated)
        {
            if (CurrentState == 0)
            {
                Instantiate(_bossPrefab, _spawnPoint.position, Quaternion.identity);
            }
            else
            {
                return;
            }
        }   
    }

    private void Update()
    {
        CheckBossState();
    }

    private void CheckBossState()
    {
        if (BossIsDefeated)
        {
            CurrentState = 1;
            PlayerPrefs.SetInt(KeyName, CurrentState);
        }
    }
}
