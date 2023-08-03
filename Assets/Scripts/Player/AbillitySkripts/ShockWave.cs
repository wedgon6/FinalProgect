using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeDestrou = 3f;
    [SerializeField] private float _speed = 6;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private int _damage = 10;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Destroy(gameObject, _timeDestrou);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.TryGetComponent(out Enemy enemy);
            enemy.TakeDamage(_damage);
            Debug.Log("Попал скилом");
            Debug.Log(_damage);
            Destroy(gameObject);
        }
    }

    public void UpDamage()
    {
        _damage*=2;
    }
}
