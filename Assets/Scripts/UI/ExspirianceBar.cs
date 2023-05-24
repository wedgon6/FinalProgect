using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExspirianceBar : MonoBehaviour
{
    [SerializeField] private Slider _exspirianseBar;
    [SerializeField] private AbilityTree _abilityTree;

    private Coroutine _coroutine;
    private float _speedChange = 0.5f;

    private void Start()
    {
        _exspirianseBar.value = _abilityTree.CurrentProgress;
    }

    private void OnEnable()
    {
        _abilityTree.ExspirianseChange += OnChangingHealth;
    }

    private void OnDisable()
    {
        _abilityTree.ExspirianseChange -= OnChangingHealth;
    }

    private void OnChangingHealth()
    {
        if (_exspirianseBar.value != _abilityTree.CurrentProgress)
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
        _exspirianseBar.DOValue(_abilityTree.CurrentProgress, _speedChange);
        yield return null;
    }
}
