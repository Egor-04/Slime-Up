using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    public static StarsSpawner StaticStarsSpawner;

    [SerializeField] private GameObject[] _stars;
    [SerializeField] private Transform[] _spawnPoints;

    [Header("Stars on Scene")]
    [SerializeField] private List<BonuceStar> _allStarsInScene;

    public bool SpawnStarsAtStart = true;

    [Tooltip("≈сли 0 значит заспавнит звезды, если 1 то не заспавнит")]
    public int CurrentState = 0;
    [SerializeField] private string KeyName = "STARS_SPAWN_STATE";

    private void Awake()
    {
        StaticStarsSpawner = this;
    }

    private void Start()
    {
        CurrentState = PlayerPrefs.GetInt(KeyName);

        if (CurrentState == 1)
        {
            SpawnStarsAtStart = false;
        }

        if (SpawnStarsAtStart) 
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                Instantiate(_stars[i], _spawnPoints[i].position, Quaternion.identity);
            } 
        }
    }

    private void Update()
    {
        CheckStarsInScene();
    }

    private void CheckStarsInScene()
    {
        if (_allStarsInScene.Count <= 0 && BossSpawner.StaticBossSpawner.BossIsDefeated)
        {
            CurrentState = 1;
            PlayerPrefs.SetInt(KeyName, CurrentState);
        }
    }

    public void AddStar(BonuceStar bonuceStar)
    {
        _allStarsInScene.Add(bonuceStar);
    }

    public void Remove(BonuceStar bonuceStar)
    {
        _allStarsInScene.Remove(bonuceStar);
    }
}
