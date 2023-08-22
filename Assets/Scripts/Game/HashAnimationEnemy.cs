using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationEnemy : MonoBehaviour
{
    private int _moveAnimation = Animator.StringToHash("walk");
    private int _attackAnimation = Animator.StringToHash("attack");
    private int _idleAnimation = Animator.StringToHash("idle");
    private int _deadAnimation = Animator.StringToHash("dead");
    private int _commboAttackAnimation = Animator.StringToHash("commboAttack");

    public int MoveAnimation => _moveAnimation;
    public int AttackAnimation => _attackAnimation;
    public int IdelAnimation => _idleAnimation;
    public int DeadAnimation => _deadAnimation;
    public int ComboAttakAnimation => _commboAttackAnimation;
}
