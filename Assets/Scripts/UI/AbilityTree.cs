using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class AbilityTree : MonoBehaviour
{
    [SerializeField] private Slider _expireanseBar;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    
    private Coroutine _coroutine;
    private float _speedChange = 0.5f;

    private int _currentProgress;
    private int _expirienceLevel = 50;
    private int _currentScore;

    private void Start()
    {
        _currentProgress = _player.Experience;
        _expireanseBar.maxValue = _expirienceLevel;
        _expireanseBar.value = _currentProgress;
        _score.text = _currentScore.ToString();
    }

    private void Update()
    {
        if (_player.Experience >= _expirienceLevel)
        {
            LevelUp();
        }
    }

    private void OnEnable()
    {
        _player.ExperienceChanged += OnExperienceChanged;
    }

    private void OnDisable()
    {
        _player.ExperienceChanged += OnExperienceChanged;
    }

    private void LevelUp()
    {
        _currentScore++;
        _score.text = _currentScore.ToString();

        int extraExpiriance = _currentProgress - _expirienceLevel;
        _currentProgress = 0;
        _currentProgress += extraExpiriance;
        _expireanseBar.value = _currentProgress;
        _player.ResetLevel();
        Debug.Log($"{extraExpiriance}, Зашел в иф");
    }

    private void OnExperienceChanged(int experience)
    {
        //if (_expireanseBar.value != _player.Experience)
        //{
        //    if (_coroutine != null)
        //    {
        //        StopCoroutine(_coroutine);
        //    }

        //    _currentProgress = _player.Experience;
        //    _coroutine = StartCoroutine(DisplayChanget());
        //}
        _currentProgress += experience;
        _expireanseBar.value = _currentProgress;
    }

    private IEnumerator DisplayChanget()
    {
        Debug.Log(_player.Experience);
        _expireanseBar.DOValue(_player.Experience, _speedChange);

        yield return null;
    }
}
