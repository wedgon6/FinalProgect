using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class PlayerAbillity : MonoBehaviour
{
    [SerializeField] private bool _isByed = false;
    [SerializeField] private string _name;
    [SerializeField] private Button _sellButton;
    [SerializeField] private bool _canBay = false;
    [SerializeField] private PlayerAbillity _nextAbillity;
    [SerializeField] private Image _image;

    public bool IsByed => _isByed;
    public string Name => _name;
    public bool CanBay => _canBay;
    public event UnityAction<PlayerAbillity> BayAbillity;

    private void Start()
    {
        //_image.color = new Color(0,0, 0, 0.5f);
    }

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
        //_image.color = new Color(this,this,this)
    }

    public void Buy()
    {
        _isByed = true;
    }

    public void OpenAbillity()
    {
        _canBay = true;
    }

    public virtual void OpenNextAbillity()
    {
        if(_nextAbillity != null)
        {
            _nextAbillity.OpenAbillity();
        }
    }
}
