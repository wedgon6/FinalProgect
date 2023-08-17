using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBottle : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.RecoverHealth(_heal);
            Destroy(gameObject);
        }
    }
}
