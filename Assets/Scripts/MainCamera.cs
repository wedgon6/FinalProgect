using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        //Vector3 temp = transform.position;
        //temp.x = _player.position.x;
        //temp.z = _player.position.z;

        //transform.position = temp;

        transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z);
    }
}
