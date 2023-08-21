using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneBossHungr : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _poisonSmoke;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Instantiate(_poisonSmoke,new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
    }
}
