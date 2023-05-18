using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpead;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    [SerializeField] private float _diveForce;

    private PlayerInpyt _playerInpyt;
    private InputAction _move;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private int _diveEnergy = 5;

    public event UnityAction<int> Dive;
    public event UnityAction NotEnergy;
    public int DiveEnergy => _diveEnergy;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerInpyt = new PlayerInpyt();
        _playerInpyt.Enable();

        _playerInpyt.Player.Attack.performed += ctx =>
        {
            if (ctx.interaction is MultiTapInteraction)
            {
                ComboAttack();
            }
        };

        //_playerInpyt.Player.Move.performed += ctx =>
        //{
        //    if (ctx.interaction is MultiTapInteraction)
        //    {
        //        Dive();
        //    }
            
        //    if (ctx.interaction is PressInteraction)
        //    {
        //        Move();
        //    }
        //};
    }

    private void FixedUpdate()
    {
        Move();
        LookAt();
    }

    private void OnEnable()
    {
        _playerInpyt.Player.Jump.started += OnJump;
        _playerInpyt.Player.Attack.started += OnAttack;
        _playerInpyt.Player.JumpAttac.started += OnJumpAttack;
        _playerInpyt.Player.Dive.started += OnDive;
        _move = _playerInpyt.Player.Move;
        _playerInpyt.Enable();
    }

    private void OnDisable()
    {
        _playerInpyt.Player.Jump.started -= OnJump;
        _playerInpyt.Player.Attack.started -= OnAttack;
        _playerInpyt.Player.JumpAttac.started -= OnJumpAttack;
        _playerInpyt.Player.Dive.started -= OnDive;
        _playerInpyt.Disable();
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 right = camera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            _direction += Vector3.up * _jumpForce;
        }
    }

    private void LookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("attakHorizont");
        _player.Attack();
    }

    private void OnJumpAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("jumpAttack");
    }
    
    private void ComboAttack()
    {
        _animator.SetTrigger("comboAttack");
        _player.ComboAttack();
    }

    private void OnDive(InputAction.CallbackContext obj)
    {
        if (_player.CanUse(_diveEnergy))
        {
            _rigidbody.AddForce(transform.forward * _diveForce, ForceMode.Impulse);
            _animator.SetTrigger("dive");
            Dive?.Invoke(_diveEnergy);
        }
        else
        {
            NotEnergy?.Invoke();
        }
    }

    private void Move()
    {
        _direction += _move.ReadValue<Vector2>().x * GetCameraRight(_camera) * _moveSpead;
        _direction += _move.ReadValue<Vector2>().y * GetCameraForward(_camera) * _moveSpead;

        _rigidbody.AddForce(_direction, ForceMode.Impulse);
        _direction = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
        {
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }
    }

    public void PlayerUseEasyStep()
    {
        _maxSpeed += 2f;
        _moveSpead += 2f;
        _diveEnergy -= 2;
    }
}
