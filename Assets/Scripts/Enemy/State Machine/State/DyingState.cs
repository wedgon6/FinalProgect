using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class DyingState : State
{
    private Animator _animator;
    private CapsuleCollider _collider;
    private float _timeDestroy = 5f;
    private float _elapsedtime;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        _collider.enabled = false;
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(_hashAnimation.DeadAnimation);
    }

    private void Update()
    {
        _elapsedtime += Time.deltaTime;

        if(_elapsedtime > _timeDestroy)
        {
            Destroy(gameObject);
        }
    }
}
