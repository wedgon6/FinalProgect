using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class AttackStateDeathBoss : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private GameObject _spell;
    [SerializeField] private GameObject _bulletDeadBoss;

    private Animator _animator;
    private Enemy _enemy;
    private float _lastAttackTime = 0;
    private float _lastComboAttackTime = 1;
    private float _delayComboAttack = 2;
    private int _countToUseSpell = 5;
    private int _currentCountToUseSpell = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_lastComboAttackTime <= 0)
        {
            ComboAttack();
            _lastComboAttackTime = _delayComboAttack;
        }

        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            UseSpell();
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

        _enemy.IsBanTransition = true;
    }

   private void ComboAttack()
    {
        _animator.SetTrigger("comboAttack");
        Instantiate(_bulletDeadBoss, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        _enemy.IsBanTransition = false;
    }

    private void UseSpell()
    {
        if(_currentCountToUseSpell <= 0)
        {
            Instantiate(_spell, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            _currentCountToUseSpell = _countToUseSpell;
        }
        else
        {
            _currentCountToUseSpell--;
        }
    }
}
