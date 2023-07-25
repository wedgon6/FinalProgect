using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunderclap : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeDestrou = 3f;

    private int _damage = 30;

    private void Update()
    {
        Destroy(gameObject, _timeDestrou);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out Enemy enemy);
            enemy.TakeDamage(_damage);
            Debug.Log("Попал мониней");
            Debug.Log(_damage);;
        }
    }

    public void UpDamage()
    {
        _damage *= 2;
    }
}
