using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transition
{
    private float _distace = 50f;

    private void Update()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance < _distace)
        {
            NeedTransit = true;
        }
    }
}
