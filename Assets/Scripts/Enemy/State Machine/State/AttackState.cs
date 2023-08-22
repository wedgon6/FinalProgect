using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    [SerializeField] private float _attacRange;
    [SerializeField] private bool _canComboAttack;

    private Animator _animator;
    private Enemy _enemy;
    private float _lastAttackTime;
    private int _counterComboAttack = 5;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
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

        if (_canComboAttack)
        {
            ÑheckComboAttac();
        }

        _animator.SetTrigger(_hashAnimation.IdelAnimation);
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if(distance <= _attacRange)
        {
            _animator.SetTrigger(_hashAnimation.AttackAnimation);
            target.TakeDamage(_damage);
        }
        else
        {
            _animator.SetTrigger(_hashAnimation.AttackAnimation);
        }
    }

    private void ÑheckComboAttac()
    {
        int countAttack = 5;

        if(_counterComboAttack > 0)
        {
            _counterComboAttack--;
        }
        else
        {
            _enemy.IsComboAttack = true;
            _counterComboAttack = countAttack;
        }
    }
}
