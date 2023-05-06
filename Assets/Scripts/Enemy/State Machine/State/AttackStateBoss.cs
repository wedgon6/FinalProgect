using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class AttackStateBoss : State
{
    [SerializeField] private float _delay;
    //[SerializeField] private float _comboAttackDelay;
    [SerializeField] private int _damage;
    //[SerializeField] private int _damageComboAttack;
    [SerializeField] private float _attackRange;

    private Animator _animator;
    private Enemy _enemy;
    private float _lastAttackTime = 0;
    private float _lastComboAttackTime = 5;
    //private Vector3 _direction;
    //private Rigidbody _rigidbody;
    //private float _jumpForce = 10;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        //_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if(_lastComboAttackTime <= 0)
        {
            //_direction += Vector3.up * _jumpForce;
            //_animator.SetTrigger("commboAttack");

            //if (IsGrounded())
            //{
            //    ComboAttack(Target);
            //}
            _enemy.IsComboAttack = true;
            //_lastComboAttackTime = _comboAttackDelay;
        }
        else if(_lastAttackTime <= 0)
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

        if(distance <= _attackRange)
        {
            _animator.SetTrigger("attack");
            target.TakeDamage(_damage);
        }
        else
        {
            _animator.SetTrigger("attack");
        }
    }

    //private void ComboAttack(Player target)
    //{
    //    Vector3 directionToTarget = transform.position - Target.transform.position;
    //    float distance = directionToTarget.magnitude;

    //    if (distance <= 10)
    //    {
    //        target.TakeDamage(_damage);
    //    }
    //}

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
