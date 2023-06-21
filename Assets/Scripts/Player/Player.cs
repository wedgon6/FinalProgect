using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxVitality;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _ordsParticle;

    private PlayerController _playerController;
    private int _currentHealth;
    private int _currentVitality;
    private float _recoveryTime = 5f;
    private float _pastTime = 0;
    private bool _canEasyStep = false;

    public int CurrentHealth => _currentHealth;
    public int CurrentVitality => _currentVitality;
    public int Experience { get; private set; }
    public List<PlayerAbillity> _abillities;
    
    public event UnityAction HealthChanged;
    public event UnityAction OnAttack;
    public event UnityAction VitalityChanged;
    public event UnityAction<int> ExperienceChanged;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentVitality = _maxVitality;
        HealthChanged?.Invoke();
        VitalityChanged?.Invoke();
        _ordsParticle.SetActive(false);
    }

    private void OnEnable()
    {
        _playerController.WastedEnergy += OnWastedEnergy;
    }

    private void OnDisable()
    {
        _playerController.WastedEnergy -= OnWastedEnergy;
    }

    private void OnWastedEnergy(int enetgy)
    {
        _currentVitality -= enetgy;
        VitalityChanged?.Invoke();
    }

    private void Update()
    {
        if(_currentVitality < _maxVitality)
        {
            RecoverVitality();
        }
    }

    private void DiveEnergy()
    {
        _currentVitality -= 10;
        VitalityChanged?.Invoke();
    }

    private void RecoverVitality()
    {

        if (_pastTime >= _recoveryTime)
        {
            _currentVitality += 5;
            VitalityChanged?.Invoke();
            _pastTime = 0;
        }
        else
        {
            _pastTime += Time.deltaTime;
        }
    }

    private void OnLevelUp(int extraExpiriance,int _expirienceLevel)
    {
        Experience -= _expirienceLevel;
        Experience += extraExpiriance;
        ExperienceChanged?.Invoke(extraExpiriance);
    }

    private bool СheckAbilliy(PlayerAbillity abillity)
    {
        for (int i = 0; i < _abillities.Count; i++)
        {
            if (_abillities[i] = abillity)
            {
                return true;
            }
        }

        return false;
    }

    public void AddAbillity(PlayerAbillity abillity)
    {
        _abillities.Add(abillity);
        UseAbbility();
    }

    private void UseAbbility()
    {
        for (int i = 0; i < _abillities.Count; i++)
        {
            if (_abillities[i].Name == "EasyStep")
            {
                AddEasyStep();
            }
            else if (_abillities[i].Name == "FuriousBlow")
            {
                _weapon.PlayerAddFuriousBlow();
            }
            else if(_abillities[i].Name == "BattleHungry")
            {
                _weapon.PlayerAddBattleHungr();
            }
            else if(_abillities[i].Name == "InnerPeace")
            {
                _playerController.PlayerAddInnerPeace();
            }
            else if (_abillities[i].Name == "SecondWind")
            {
                AddSecondWind();
            }
            else if (_abillities[i].Name == "ShockWave")
            {
                _weapon.PlayerAddShockWave();
            }
            else if (_abillities[i].Name == "Thunderbolt")
            {
                _weapon.PlayerAddThunderbolt();
            }
            else if (_abillities[i].Name == "PowerOfHeaven")
            {
                _weapon.PlayerAddPowerOfHeaven();
            }
            else if (_abillities[i].Name == "Novice")
            {
                PlayerAddNovice();
            }
            else if (_abillities[i].Name == "Thunderclap")
            {
                _playerController.PlayerAddThunderclap();
            }
        }
    }

    private void AddEasyStep()
    {
        if (_canEasyStep == false)
        {
            _playerController.PlayerAddEasyStep();
            _canEasyStep = true;
        }
    }

    private void AddSecondWind()
    {
        Debug.Log("Уменьшил Время востановления");
        _recoveryTime -= 2f;
    }

    public void ResetLevel()
    {
        Experience -= 50;
        ExperienceChanged?.Invoke(0);
    }

    public void Attack()
    {
        OnAttack?.Invoke();
        _weapon.ApplyDamage();
    }

    public void ComboAttack()
    {
        _weapon.UseComboAttack();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Получаю урон");
        HealthChanged?.Invoke();
    }

    public void RecoverHealth(int healing)
    {
        _currentHealth += healing;
    }

    public void OnEnemyDied(int experience)
    {
        Experience += experience;
        ExperienceChanged?.Invoke(experience);
    }

    public bool CanUse(int energy)
    {
        if (_currentVitality <= energy)
        {
            return false;
        }

        return true;
    }

    private void PlayerAddNovice()
    {
        Debug.Log("Включаю орбы");
        _ordsParticle.SetActive(true);
    }
}
