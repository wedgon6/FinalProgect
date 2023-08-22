using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent((typeof(Animator)))]
public class ComboAttacErrorMonsterState : State
{
    [SerializeField] private GameObject _particlePoison;

    private Enemy _enemy;
    private Animator _animator;
    private float _timeAnimation = 5f;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        _particlePoison.SetActive(false);
        _particlePoison.SetActive(true);
        _animator.SetTrigger(_hashAnimation.ComboAttakAnimation);
    }

    private void Update()
    {
        if (_timeAnimation > 0)
        {
            _timeAnimation--;
        }
        else
        {
            StopComboAttac();
        }
    }

    private void UsePoison()
    {
        _particlePoison.SetActive(true);
        _animator.SetTrigger(_hashAnimation.ComboAttakAnimation);
    }

    private void StopComboAttac()
    {
        _particlePoison.SetActive(true);
        _enemy.IsComboAttack = false;
    }
}
