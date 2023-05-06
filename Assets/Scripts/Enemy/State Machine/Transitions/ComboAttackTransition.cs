using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class ComboAttackTransition : Transition
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if(_enemy.IsComboAttack == true)
        {
            NeedTransit = true;
        }
    }
}
