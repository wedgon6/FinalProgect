using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AbilityTree : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<PlayerAbillity> _abillities;

    private int _currentProgress = 0;
    private int _expirienceLevel = 50;
    private int _currentScore = 0;
    private int _totalScore = 0;

    public int Score => _currentScore;
    public int CurrentProgress => _currentProgress;
    public int TotalScore => _totalScore;
    public event UnityAction ExspirianseChange;
    public event UnityAction ScoreChange;

    private void Start()
    {
        _currentProgress = _player.Experience;
        ScoreChange?.Invoke();
        ExspirianseChange?.Invoke();

        for (int i = 0; i < _abillities.Count; i++)
        {
            _abillities[i].BayAbillity += OnSellButtonClick;
        }
    }

    private void Update()
    {
        if (_player.Experience >= _expirienceLevel)
            LevelUp();
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
        _totalScore += 1;
        ScoreChange?.Invoke();

        int extraExpiriance = _currentProgress - _expirienceLevel;
        _currentProgress = 0;
        _currentProgress += extraExpiriance;
        _player.ResetLevel();
        ExspirianseChange?.Invoke();
    }

    private void OnExperienceChanged(int experience)
    {
        _currentProgress += experience;
        ExspirianseChange?.Invoke();
        ExspirianseChange?.Invoke();
    }

    private void OnSellButtonClick(PlayerAbillity abillity)
    {
        TrySellAbility(abillity);
    }

    private void TrySellAbility(PlayerAbillity abillity)
    {
        if(_currentScore > 0)
        {
            if (abillity.CanBay)
            {
                if (abillity.IsByed == false)
                {
                    _player.AddAbillity(abillity);
                    _currentScore--;
                    abillity.Buy();
                    abillity.OpenNextAbillity();
                    abillity.BayAbillity -= OnSellButtonClick;
                    ScoreChange?.Invoke();
                }
            }
        }
    }

    public void GetPlayerData(int score, int progress)
    {
        _currentScore = score;
        _currentProgress = progress;

        ScoreChange?.Invoke();
        ExspirianseChange?.Invoke();
    }
}
