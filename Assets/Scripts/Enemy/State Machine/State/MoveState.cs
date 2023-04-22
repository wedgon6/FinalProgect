using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        transform.LookAt(Target.transform.position);
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, _moveSpeed * Time.fixedDeltaTime);
    }
}
