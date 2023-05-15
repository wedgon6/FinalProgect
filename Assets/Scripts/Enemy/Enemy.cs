using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _revard;
    [SerializeField] private Player _target;

    private Animator _animator;

    public Player Target => _target;
    public int Health => _health;
    public bool IsComboAttack;
    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damege)
    {
        _health -= damege;

        if( _health < 0)
        {
            Dying?.Invoke(this);
            _target.OnEnemyDied(_revard);
        }
    }
}
