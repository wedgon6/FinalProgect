using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private AbilityTree _abilityTree;
    [SerializeField] private TMP_Text _score;

    //private void Start()
    //{
    //    _score.text = _abilityTree.Score.ToString();
    //}

    private void OnEnable()
    {
        _abilityTree.ScoreChange += OnChangingScore;
    }

    private void OnDisable()
    {
        _abilityTree.ScoreChange -= OnChangingScore;
    }

    private void OnChangingScore()
    {
        _score.text = _abilityTree.Score.ToString();
    }
}
