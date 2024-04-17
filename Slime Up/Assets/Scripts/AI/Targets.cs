using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header("Target")]
    public Enemy Enemy;// ���� ���� ���������� �� ����� ���������� ��������� ����, � ������� UpdateGenerator 
    [SerializeField] private Transform[] _patrolTargets;

    private void Start()
    {
        Enemy.GetPatrolTargets(_patrolTargets[0], _patrolTargets[1]);
    }
}
