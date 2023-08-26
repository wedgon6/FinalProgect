using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
   
    private int _damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
    }

    public void UpDamage()
    {
        _damage*=2;
    }
}
