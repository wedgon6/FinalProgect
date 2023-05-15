//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;
//using static UnityEngine.GraphicsBuffer;

//public class ProgressBar : MonoBehaviour
//{
//    [SerializeField] private Slider _expireanseBar;
//    [SerializeField] private AbilityTree _expireansePlayer;

//    private Coroutine _coroutine;
//    private float _speedChange = 0.5f;

//    private void Start()
//    {
//        _healthBar.value = _healthPlayer.CurrentHealth;
//    }

//    private void OnEnable()
//    {
//        _healthPlayer.HealthChanged += OnChangingHealth;
//    }

//    private void OnDisable()
//    {
//        _healthPlayer.HealthChanged -= OnChangingHealth;
//    }

//    private void OnChangingHealth()
//    {
//        if (_healthBar.value != _healthPlayer.CurrentHealth)
//        {
//            if (_coroutine != null)
//            {
//                StopCoroutine(_coroutine);
//            }

//            _coroutine = StartCoroutine(DisplayChanget());
//        }
//    }

//    private IEnumerator DisplayChanget()
//    {
//        _healthBar.DOValue(_healthPlayer.CurrentHealth, _speedChange);
//        yield return null;
//    }
//}
