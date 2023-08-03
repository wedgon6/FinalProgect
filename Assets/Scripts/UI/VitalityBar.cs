using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VitalityBar : MonoBehaviour
{
    [SerializeField] private Slider _vitalityBar;
    [SerializeField] private Player _vitalityPlayer;

    private Coroutine _coroutine;
    private float _speedChange = 0.5f;

    private void Start()
    {
        _vitalityBar.value = _vitalityPlayer.CurrentVitality;
    }

    private void OnEnable()
    {
        _vitalityPlayer.VitalityChanged += OnChangingVitality;
    }

    private void OnDisable()
    {
        _vitalityPlayer.VitalityChanged -= OnChangingVitality;
    }

    private void OnChangingVitality()
    {
        if (_vitalityBar.value != _vitalityPlayer.CurrentVitality)
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
        _vitalityBar.DOValue(_vitalityPlayer.CurrentVitality, _speedChange);
        yield return null;
    }
}
