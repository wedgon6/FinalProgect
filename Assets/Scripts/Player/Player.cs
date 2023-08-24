using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    const string AbillityEasyStep = "EasyStep";
    const string AbillityFuriousBlow = "FuriousBlow";
    const string AbillityBattleHungry = "BattleHungry";
    const string AbillityInnerPeace = "InnerPeace";
    const string AbillitySecondWind = "SecondWind";
    const string AbillityShockWave = "ShockWave";
    const string AbillityThunderbolt = "Thunderbolt";
    const string AbillityPowerOfHeaven = "PowerOfHeaven";
    const string AbillityNovice = "Novice";
    const string AbillityThunderclap = "Thunderclap";

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxVitality;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _ordsParticle;
    [SerializeField] private SaveManager _saveManager;

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
    public event UnityAction PlaeyDie;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    private void Start()
    {
        _saveManager.LoadPalyerData();
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

    private bool ÑheckAbilliy(PlayerAbillity abillity)
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
            if (_abillities[i].Name == AbillityEasyStep)
            {
                AddEasyStep();
            }
            else if (_abillities[i].Name == AbillityFuriousBlow)
            {
                _weapon.PlayerAddFuriousBlow();
            }
            else if(_abillities[i].Name == AbillityBattleHungry)
            {
                _weapon.PlayerAddBattleHungr();
            }
            else if(_abillities[i].Name == AbillityInnerPeace)
            {
                _playerController.PlayerAddInnerPeace();
            }
            else if (_abillities[i].Name == AbillitySecondWind)
            {
                AddSecondWind();
            }
            else if (_abillities[i].Name == AbillityShockWave)
            {
                _weapon.PlayerAddShockWave();
            }
            else if (_abillities[i].Name == AbillityThunderbolt)
            {
                _weapon.PlayerAddThunderbolt();
            }
            else if (_abillities[i].Name == AbillityPowerOfHeaven)
            {
                _weapon.PlayerAddPowerOfHeaven();
            }
            else if (_abillities[i].Name == AbillityNovice)
            {
                PlayerAddNovice();
            }
            else if (_abillities[i].Name == AbillityThunderclap)
            {
                _weapon.PlayerAddTunderclap();
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

    public void JumpAttack()
    {
        _weapon.UseJumpAttack();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke();

        if(_currentHealth <= 0)
        {
            PlaeyDie?.Invoke();
        }
    }

    public void RecoverHealth(int healing)
    {
        if(_currentHealth < _maxHealth)
        {
            if((_currentHealth+healing >= _maxHealth))
            {
                _currentHealth = _maxHealth;
                HealthChanged?.Invoke();
            }
            else
            {
                _currentHealth += healing;
                HealthChanged?.Invoke();
            }
        }
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
        _ordsParticle.SetActive(true);
    }

    public void GetPlayerData(int health,int vitality)
    {
        _currentHealth = health;
        _currentVitality = vitality;
        HealthChanged?.Invoke();
        VitalityChanged?.Invoke();
    }

    public void SaveData()
    {
        _saveManager.SavePlayerData();
    }
}
