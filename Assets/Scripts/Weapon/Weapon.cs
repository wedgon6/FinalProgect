using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _thunderboltParticle;

    private BoxCollider _collider;
    private Player _player;
    public int Damage => _damage;
    private int _critDamage;
    private float _chanceCritDamage = 0;
    private float _chanceVampirism = 0;
    private int _multiplierDamage = 2;
    private float _attackDistance = 4;


    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        _player = GetComponent<Player>();
        

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if(collision.gameObject.layer == 6)
    //    //{
    //    //    collision.gameObject.TryGetComponent(out Enemy enemy);
    //    //    enemy.TakeDamage(_damage);
    //    //    Debug.Log("Попал");
    //    //    _collider.enabled = false;
    //    //}

    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        collision.gameObject.TryGetComponent(out Enemy enemy);
    //        enemy.TakeDamage(_damage);
    //        Debug.Log("Попал");
    //        _collider.enabled = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //if(collision.gameObject.layer == 6)
        //{
        //    collision.gameObject.TryGetComponent(out Enemy enemy);
        //    enemy.TakeDamage(_damage);
        //    Debug.Log("Попал");
        //    _collider.enabled = false;
        //}

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out Enemy enemy);
            int currentDamage = _damage + CalculationCritDamage();
            enemy.TakeDamage(currentDamage);
            Debug.Log("Попал");
            if (IsVampirism())
            {
                _player.RecoverHealth(currentDamage);
            }

            _collider.enabled = false;
        }
    }

    private int CalculationCritDamage()
    {
        _critDamage = _damage;
        _multiplierDamage = 2;

        if(Random.Range(0,100) <= _chanceCritDamage)
        {
            _critDamage *= _multiplierDamage;
            return _critDamage;
        }

        return _critDamage;
    }

    private bool IsVampirism()
    {
        if (Random.Range(0, 100) <= _chanceVampirism)
        {
            return true;
        }

        return false;
    }

    public void ApplyDamage()
    {
        _collider.enabled = true;
    }

    public void UseComboAttack()
    {
        _collider.enabled = true;
        var colliders = Physics.OverlapSphere(transform.position, _attackDistance);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage + CalculationCritDamage());
            }
        }
    }

    public void PlayerAddFuriousBlow()
    {
        _chanceCritDamage = 25f;
    }

    public void PlayerAddBattleHungr()
    {
        _chanceVampirism = 15;
    }
}
