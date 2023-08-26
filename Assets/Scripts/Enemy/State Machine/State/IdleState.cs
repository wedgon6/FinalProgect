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
        //_animation.SetTrigger("idle");
        foreach (var trigger in _animation.parameters)
        {
            if (trigger.type == AnimatorControllerParameterType.Trigger)
                _animation.ResetTrigger(trigger.name);
        }
    }
}

