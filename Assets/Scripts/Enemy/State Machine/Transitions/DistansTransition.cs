using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DistansTransition : Transition
{
    [SerializeField] private float _distance;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if(_enemy.IsBanTransition == false)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < _distance)
            {
                NeedTransit = true;
            }
        }
    }
}

