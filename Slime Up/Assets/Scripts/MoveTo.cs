using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Transform _moveTo;

    private void Update()
    {
        transform.position = new Vector3(_moveTo.position.x, _moveTo.position.y, 0f);
    }
}
