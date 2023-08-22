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
    protected HashAnimationPlayer _hashAnimation = new HashAnimationPlayer();

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat(_hashAnimation.Speed, _rigidbody.velocity.magnitude / _maxSpeed);
    }
}
