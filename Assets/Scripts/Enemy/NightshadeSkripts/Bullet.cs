using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeDestrou = 3f;
    [SerializeField] private float _speed = 6;

    private int _damage = 10;

    private void Update()
    {
        Destroy(gameObject, _timeDestrou);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.TryGetComponent(out Player player);
            player.TakeDamage(_damage);
            Debug.Log(_damage);
            Destroy(gameObject);
        }
    }
}
