using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IdleState : State
{
    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }
}
