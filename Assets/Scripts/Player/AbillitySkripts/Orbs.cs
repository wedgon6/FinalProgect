using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
   
    private int _damage = 10;

    private void Start()
    {
        //_damage = TakeDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out Enemy enemy);
            enemy.TakeDamage(_damage);
            Debug.Log("Попал орбом");
            Debug.Log(_damage);
        }
    }

    public void UpDamage()
    {
        _damage*=2;
    }
}
