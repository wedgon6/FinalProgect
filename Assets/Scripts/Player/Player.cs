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

    public void Attack()
    {
        OnAttack?.Invoke();
        _weapon.ApplyDamage();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke();
    }

    public void OnEnemyDied(int experience)
    {
        Experience += experience;
    }

    public bool CanUse()
    {
        if (_currentVitality <= 0)
        {
            return false;
        }

        return true;
    }
}
