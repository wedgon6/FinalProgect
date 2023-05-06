using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Animator)))]
[RequireComponent(typeof(Enemy))]
public class ComboAttackWarState : State
{
    [SerializeField] private int _damageComboAttack;
    [SerializeField] private float _attackRange;

    private Vector3 _direction;
    private Animator _animator;
    private Enemy _enemy;
    private Rigidbody _rigidbody;
    private float _jumpForce = 10;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        ComboAttack(Target);
    }

    private void ComboAttack(Player target)
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        _direction += Vector3.up * _jumpForce;
        _animator.SetTrigger("commboAttack");

        if (distance <= 10)
        {
            target.TakeDamage(_damageComboAttack);
        }

        _enemy.IsComboAttack = false;
    }
}
