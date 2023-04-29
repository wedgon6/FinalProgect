using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] int _damage;

    private BoxCollider _collider;
    private Player _player;
    public int Damage => _damage;
    

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.gameObject.TryGetComponent(out Enemy enemy);
            enemy.TakeDamage(_damage);
            Debug.Log("Попал");
            _collider.enabled = false;
        }
    }

    public void ApplyDamage()
    {
        _collider.enabled = true;
    }
}
