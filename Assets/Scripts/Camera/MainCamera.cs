using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MainCamera : MonoBehaviour
{
    //[SerializeField] private float _rotateSpeed;

    //private PlayerInpyt _inputActions;
    //private Vector2 _rotate;
    //private Vector2 _rotation;


    //private void Awake()
    //{
    //    _inputActions = new PlayerInpyt();
    //    _inputActions.Enable();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        transform. += Vector3.right * 90;
    //        Debug.Log("Поворот");
    //    }
    //}

    //private void Look(Vector2 rotate)
    //{
    //    if (rotate.sqrMagnitude < 0.1)
    //    {
    //        return;
    //    }

    //    float scaleRotateSpeed = _rotateSpeed * Time.deltaTime;
    //    _rotation.y += rotate.x * scaleRotateSpeed;
    //    _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaleRotateSpeed, -90, 90);
    //    //transform.localEulerAngles = _rotation;
    //}



    //private void LateUpdate()
    //{
    //    //Vector3 temp = transform.position;
    //    //temp.x = _player.position.x;
    //    //temp.z = _player.position.z;

    //    //transform.position = temp;

    //    //transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z);
    //}
}
