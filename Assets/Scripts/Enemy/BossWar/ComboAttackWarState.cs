using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Animator)))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Rigidbody))]
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
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ComboAttack(Target);
        Jump();
    }

    private void Jump()
    {
        _rigidbody.isKinematic = false;
        _direction += Vector3.up * _jumpForce;
        _rigidbody.AddForce(_direction, ForceMode.Impulse);
        _direction = Vector3.zero;
    }

    private void ComboAttack(Player target)
    {
       
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        _animator.SetTrigger("commboAttack");

        if (distance <= 10)
        {
            target.TakeDamage(_damageComboAttack);
        }

        _enemy.IsComboAttack = false;
    }
}
