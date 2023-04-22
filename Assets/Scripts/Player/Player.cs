using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Weapon _weapon;

    private int _currentHealth;
    public int Experience { get; private set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Attack()
    {
        _weapon.ApplyDamage();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    public void OnEnemyDied(int experience)
    {
        Experience += experience;
    }
}
