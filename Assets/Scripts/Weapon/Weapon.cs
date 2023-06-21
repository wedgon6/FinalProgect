using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _magicDanage;
    [SerializeField] private GameObject _thunderboltParticle;
    [SerializeField] private ShockWave _shockWave;
    [SerializeField] private Player _player;

    private BoxCollider _collider;
    public int Damage => _damage;
    public int MagicDanage => _magicDanage;

    private int _critDamage;
    private float _chanceCritDamage = 0;
    private float _chanceVampirism = 0;
    private int _multiplierDamage = 2;
    private float _attackDistance = 4;
    private bool isShockWaveBuy = false;

    public bool IsShockWaveBuy => isShockWaveBuy;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        _thunderboltParticle.SetActive(false);
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
            int currentDamage = _damage + CalculationCritDamage()+_magicDanage;
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
                enemy.TakeDamage(_damage + CalculationCritDamage()+_magicDanage);
            }
        }

        if(isShockWaveBuy == true)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float angleX = _player.transform.eulerAngles.x;
            float angleY = _player.transform.eulerAngles.y;
            float angleZ = _player.transform.eulerAngles.z;

            Instantiate(_shockWave, position,Quaternion.Euler(angleX, angleY, angleZ));
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

    public void PlayerAddShockWave()
    {
        isShockWaveBuy = true;
    }

    public void PlayerAddThunderbolt()
    {
        _thunderboltParticle.SetActive(true);
        _magicDanage += 4;
    }

    public void PlayerAddPowerOfHeaven()
    {
        _magicDanage *= 2;
        _shockWave.UpDamage();
    }

    public int GetMagicDamage()
    {
        return MagicDanage;
    }
}
