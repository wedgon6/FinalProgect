using UnityEngine;

public class Tunderclap : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeDestrou = 3f;

    private int _damage = 30;

    private void Update()
    {
        Destroy(gameObject, _timeDestrou);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void UpDamage()
    {
        _damage *= 2;
    }
}
