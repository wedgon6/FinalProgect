using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistansTransition : Transition
{
    [SerializeField] private float _distance;

    private void Update()
    {
        //Vector3 directionToTarget = transform.position - Target.transform.position;
        //float distance = directionToTarget.magnitude;

        //if (distance < _distance)
        //{
        //    NeedTransit = true;
        //}

        if (Vector3.Distance(transform.position, Target.transform.position) < _distance)
        {
            NeedTransit = true;
        }
    }
}

