using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        //if (Vector2.Distance(transform.position, Target.transform.position) <= _transitionRange)    
        //{
        //    NeedTransit = true;
        //}

        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
