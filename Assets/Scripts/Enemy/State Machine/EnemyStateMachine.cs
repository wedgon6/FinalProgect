using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _idleState;

    private Player _target;
    private State _currentState;
    private int _health;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        _health = GetComponent<Enemy>().Health;
        Reset(_idleState);
    }

    private void Update()
    {
        if(_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if(nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State idleState)
    {
        _currentState = idleState;

        if(_currentState != null)
        {
            _currentState.EnterState(_target);
        }
    }

    private void Transit(State nextState)
    {
        if(_currentState != null)
        {
            _currentState.ExitState();
        }

        _currentState = nextState;

        if(_currentState != null)
        {
            _currentState.EnterState(_target);
        }
    }
}
