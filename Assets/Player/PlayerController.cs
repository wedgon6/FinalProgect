using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpead;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Camera _camera;

    private PlayerInpyt _playerInpyt;
    private InputAction _move;
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerInpyt = new PlayerInpyt();
        _playerInpyt.Enable();

    }

    private void Update()
    {
        //_direction = _playerInpyt.Player.Move.ReadValue<Vector3>();
        _direction += _move.ReadValue<Vector2>().x * GetCameraRight(_camera) * _maxSpeed;
        _direction += _move.ReadValue<Vector2>().y * GetCameraForward(_camera) * _maxSpeed;
        _rigidbody.AddForce(_direction, ForceMode.Impulse);
        _direction = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
        {
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;
        }

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;

        if(horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }

        LookAt();
        //Move(_direction);
    }

    private void OnEnable()
    {
        _playerInpyt.Player.Jump.started += OnJump;
        _playerInpyt.Player.Attack.started += OnAttack;
        _move = _playerInpyt.Player.Move;
        _playerInpyt.Enable();
    }

    private void OnDisable()
    {
        _playerInpyt.Player.Jump.started -= OnJump;
        _playerInpyt.Player.Attack.started -= OnAttack;
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
    }
}
