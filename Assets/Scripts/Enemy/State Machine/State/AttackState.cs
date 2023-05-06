using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    [SerializeField] private float _attacRange;

    private Animator _animator;
    private float _lastAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay; 
        }

        _animator.SetTrigger("idle");
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if(distance <= _attacRange)
        {
            _animator.SetTrigger("attack");
            target.TakeDamage(_damage);
        }
        else
        {
            _animator.SetTrigger("attack");
        }
    }
}
