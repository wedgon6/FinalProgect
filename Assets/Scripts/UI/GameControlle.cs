using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControlle : MonoBehaviour
{
    [SerializeField] private GameObject _abilityTree;
    
    private PlayerInpyt _input;
    private bool _isOpen;

    private void Awake()
    {
        _input = new PlayerInpyt();
        _input.Enable();
        _isOpen = true;
    }

    private void OnEnable()
    {
        _input.Game.OpenAbillityTree.started += OpenAbillityTree;
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Game.OpenAbillityTree.started -= OpenAbillityTree;
        _input.Disable();
    }

    private void OpenAbillityTree(InputAction.CallbackContext obj)
    {
        if (_isOpen == false)
        {
            _abilityTree.SetActive(true);
            _isOpen = true;
        }
        else
        {
            _abilityTree.SetActive(false);
            _isOpen = false;
        }
    }
}
