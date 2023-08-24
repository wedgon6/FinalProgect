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
    [SerializeField] private Tunderclap _tunderclapEffect;

    private BoxCollider _collider;
    public int Damage => _damage;
    public int MagicDanage => _magicDanage;

    private int _critDamage;
    private int _multiplierDamage = 2;
    private int _minRange = 0;
    private int _maxRange = 100;

    private float _chanceCritDamage = 0;
    private float _chanceVampirism = 0;
    private float _attackDistance = 4;

    private bool _isShockWaveBuy = false;
    private bool _isTunderclap = false;
    private bool _canVampirism = false;

    public bool IsShockWaveBuy => _isShockWaveBuy;
    public bool IsTunderclap => _isTunderclap;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        _thunderboltParticle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        int damegeSplitter = 2;

        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            int currentDamage = _damage + CalculationCritDamage()+_magicDanage;
            enemy.TakeDamage(currentDamage);

            if (IsVampirism())
            {
                _player.RecoverHealth(currentDamage/damegeSplitter);
            }

            _collider.enabled = false;
        }
    }

    private int CalculationCritDamage()
    {
        _critDamage = _damage;
        _multiplierDamage = 2;

        if(Random.Range(_minRange,_maxRange) <= _chanceCritDamage)
        {
            _critDamage *= _multiplierDamage;
            return _critDamage;
        }

        return _critDamage;
    }

    private bool IsVampirism()
    {
        if (_canVampirism)
        {
            if (Random.Range(_minRange, _maxRange) <= _chanceVampirism)
            {
                return true;
            }
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

        if(_isShockWaveBuy == true)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            float angleX = _player.transform.eulerAngles.x;
            float angleY = _player.transform.eulerAngles.y;
            float angleZ = _player.transform.eulerAngles.z;

            Instantiate(_shockWave, position,Quaternion.Euler(angleX, angleY, angleZ));
        }
    }

    public void UseJumpAttack()
    {
        int bonusDistanceY = 5;

        _collider.enabled = true;
        var colliders = Physics.OverlapSphere(transform.position, _attackDistance);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage + CalculationCritDamage() + _magicDanage);
            }
        }

        if (_isTunderclap)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y+ bonusDistanceY, transform.position.z);
            Instantiate(_tunderclapEffect,position,Quaternion.Euler(0,0,0));
        }
    }

    public void PlayerAddFuriousBlow()
    {
        _chanceCritDamage = 25f;
    }

    public void PlayerAddBattleHungr()
    {
        _chanceVampirism = 20f;
        _canVampirism = true;
    }

    public void PlayerAddShockWave()
    {
        _isShockWaveBuy = true;
    }

    public void PlayerAddTunderclap()
    {
        _isTunderclap = true;
    }

    public void PlayerAddThunderbolt()
    {
        int bonusDamage = 4;

        _thunderboltParticle.SetActive(true);
        _magicDanage += bonusDamage;
    }

    public void PlayerAddPowerOfHeaven()
    {
        int bonusDamage = 2;

        _magicDanage *= bonusDamage;
        _shockWave.UpDamage();
    }

    public int GetMagicDamage()
    {
        return MagicDanage;
    }
}
