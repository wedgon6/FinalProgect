using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class AttackStateNightshade : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    [SerializeField] private float _attacRange;
    [SerializeField] private bool _canComboAttack;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private GameObject _bullet;

    private Animator _animator;
    private Enemy _enemy;
    private float _lastAttackTime;
    private int _counterComboAttack = 5;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (_lastAttackTime <= 0)
        {
            Vector3 position = new Vector3(_shootPoint.transform.position.x, _shootPoint.transform.position.y, _shootPoint.transform.position.z);

            _animator.SetTrigger(_hashAnimation.AttackAnimation);
            Instantiate(_bullet, position, transform.rotation);
            _lastAttackTime = _delay;
        }

        if (_canComboAttack)
        {
            ÑheckComboAttac();
        }

        _animator.SetTrigger(_hashAnimation.IdelAnimation);
        _lastAttackTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.LookAt(Target.transform.position);
    }

    private void ÑheckComboAttac()
    {
        int countAttack = 5;

        if (_counterComboAttack > 0)
        {
            _counterComboAttack--;
        }
        else
        {
            _enemy.IsComboAttack = true;
            _counterComboAttack = countAttack;
        }
    }
}
