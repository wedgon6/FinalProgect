using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class PlayerAbillity : MonoBehaviour
{
    public enum AbillityType
    {
        None,
        EasyStep,
        SecondWind,
        BattleHungry,
        FuriousBlow,
        InnerPeace,
        ShockWave,
        Thunderbolt,
        Thunderclap, //юзабельный
        PowerOfHeaven,
        Novice
    }
    [SerializeField] private bool _isByed = false;
    [SerializeField] private string _name;
    [SerializeField] private Button _sellButton;

    public bool IsByed => _isByed;
    public string Name => _name;
    public event UnityAction<PlayerAbillity> BayAbillity;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        BayAbillity?.Invoke(this);
    }
    public void Buy()
    {
        _isByed = true;
    }
}
