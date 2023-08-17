using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletDeadBoss : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
