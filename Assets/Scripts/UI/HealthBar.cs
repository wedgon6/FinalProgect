using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Player _healthPlayer;

    private Coroutine _coroutine;
    private float _speedChange = 0.5f;

    private void Start()
    {
        _healthBar.value = _healthPlayer.CurrentHealth;
    }

    private void OnEnable()
    {
        _healthPlayer.HealthChanged += OnChangingHealth;
    }

    private void OnDisable()
    {
        _healthPlayer.HealthChanged -= OnChangingHealth;
    }

    private void OnChangingHealth()
    {
        if (_healthBar.value != _healthPlayer.CurrentHealth)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(DisplayChanget());
        }
    }

    private IEnumerator DisplayChanget()
    {
        _healthBar.DOValue(_healthPlayer.CurrentHealth, _speedChange);
        yield return null;
    }
}
