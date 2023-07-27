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
        //Vector3 directionToTarget = transform.position - Target.transform.position;
        //float distance = directionToTarget.magnitude;

        //if (distance < _distance)
        //{
        //    NeedTransit = true;
        //}
        if(_enemy.IsBanTransition == false)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < _distance)
            {
                NeedTransit = true;
            }
        }
    }
}

