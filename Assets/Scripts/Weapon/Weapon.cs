using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] int _damage;

    private Collider _collider;
    public int Damage => _damage;
    

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void ApplyDamage()
    {
        
    }
}
