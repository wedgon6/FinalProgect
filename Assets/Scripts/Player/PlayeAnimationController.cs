using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class PlayeAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _maxSpeed = 5f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat("speed", _rigidbody.velocity.magnitude / _maxSpeed);
    }
}
