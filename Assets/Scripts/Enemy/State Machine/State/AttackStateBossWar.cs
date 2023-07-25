using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class AttackStateBossWar : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRange;

    private Animator _animator;
    private Enemy _enemy;
    private float _lastAttackTime = 0;
    private float _lastComboAttackTime = 2;
    private float _delayComboAttack = 7;   

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastComboAttackTime <= 0)
        {
            _enemy.IsComboAttack = true;
            _lastComboAttackTime = _delayComboAttack;
        }
        
        if(_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _animator.SetTrigger("idle");
        _lastAttackTime -= Time.deltaTime;
        _lastComboAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= _attackRange)
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
