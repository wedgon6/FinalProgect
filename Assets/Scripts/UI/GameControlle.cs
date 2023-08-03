using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControlle : MonoBehaviour
{
    [SerializeField] private GameObject _abilityTree;
    [SerializeField] private GameObject _gameMenu;
    
    private PlayerInpyt _input;
    private bool _isOpenAbilityTree;
    private bool _isOpenGameMenu;

    private void Awake()
    {
        _input = new PlayerInpyt();
        _input.Enable();
        _isOpenAbilityTree = true;
    }

    private void OnEnable()
    {
        _input.Game.OpenAbillityTree.started += OpenAbillityTree;
        _input.Game.OpenMenu.started += OpenGameMenu;
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Game.OpenAbillityTree.started -= OpenAbillityTree;
        _input.Game.OpenMenu.started -= OpenGameMenu;
        _input.Disable();
    }

    private void OpenAbillityTree(InputAction.CallbackContext obj)
    {
        if (_isOpenAbilityTree == false)
        {
            _abilityTree.SetActive(true);
            _isOpenAbilityTree = true;
        }
        else
        {
            _abilityTree.SetActive(false);
            _isOpenAbilityTree = false;
        }
    }

    private void OpenGameMenu(InputAction.CallbackContext obj)
    {
        if (_isOpenGameMenu == false)
        {
            _gameMenu.SetActive(true);
            _isOpenGameMenu = true;
            Time.timeScale = 0;
        }
        else
        {
            _gameMenu.SetActive(false);
            _isOpenGameMenu = false;
            Time.timeScale = 1;
        }
    }
}
