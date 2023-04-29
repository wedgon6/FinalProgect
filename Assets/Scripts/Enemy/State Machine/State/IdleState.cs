using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IdleState : State
{
    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }
}
