using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _maxSpeed = 4f;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.isKinematic = true;
        transform.LookAt(Target.transform.position);
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, _moveSpeed * Time.fixedDeltaTime);

        _animator.SetTrigger("walk");

        _direction = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
        _rigidbody.AddForce(_direction * _moveSpeed);
        _direction = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
        {
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }
    }

    private void RunAnimation()
    {
        _animator.SetBool("isRun", true);
    }
}
