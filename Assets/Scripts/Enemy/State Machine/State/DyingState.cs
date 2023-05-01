using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DyingState : State
{
    private Animator _animator;
    private float _timeDestroy = 5f;
    private float _elapsedtime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("dead");
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
