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

    private PlayerController _playerController;
    private int _currentHealth;
    private int _currentVitality;
    private float _recoveryTime = 5f;
    private float _pastTime = 0;

    public int CurrentHealth => _currentHealth;
    public int CurrentVitality => _currentVitality;
    public int Experience { get; private set; }
    
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
    }

    private void OnEnable()
    {
        _playerController.Dive += OnWastedEnergy;
    }

    private void OnDisable()
    {
        _playerController.Dive -= OnWastedEnergy;
    }

    private void OnWastedEnergy(int enetgy)
    {
        _currentVitality -= enetgy;
        VitalityChanged?.Invoke();
    }

    private void Update()
    {
        RecoverVitality();
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

    private void PlayerAbillityOnAbillityUnlocked(object sender, PlayerAbillity.OnAbillityUlockedEventArgs eventArgs)
    {
        switch (eventArgs.AbillityType)
        {
            case PlayerAbillity.AbillityType.EasyStep:
                UseEasyStep();
                break;
            case PlayerAbillity.AbillityType.SecondWind:
                UseSecondWind();
                break;
        }
    }

    private void UseEasyStep()
    {
        _playerController.PlayerUseEasyStep();
        Debug.Log("Легкий ШАг");
    }

    private void UseSecondWind()
    {
        _recoveryTime -= 2f;
        Debug.Log("Уменьшил Время востановления");
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

    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke();
    }

    public void OnEnemyDied(int experience)
    {
        Experience += experience;
        ExperienceChanged?.Invoke(experience);
    }

    public bool CanUse(int enegy)
    {
        if (_currentVitality <= 0)
        {
            return false;
        }

        return true;
    }
}
