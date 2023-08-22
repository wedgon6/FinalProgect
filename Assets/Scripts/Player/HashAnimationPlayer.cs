using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimationPlayer : MonoBehaviour
{
    private int _attackAnimation = Animator.StringToHash("attakHorizont");
    private int _jumpAttackAnimation = Animator.StringToHash("jumpAttack");
    private int _comboAttackAnimation = Animator.StringToHash("comboAttack");
    private int _diveAnimation = Animator.StringToHash("dive");
    private int _speed = Animator.StringToHash("speed");

    public int AttackAnimation => _attackAnimation;
    public int JumpAttackAnimation => _jumpAttackAnimation;
    public int ComboAttackAnimation => _comboAttackAnimation;
    public int DiveAnimation => _diveAnimation;
    public int Speed => _speed;
}
