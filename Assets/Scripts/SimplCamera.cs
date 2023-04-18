using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed = 5f;
    [SerializeField] private LayerMask _maskObstacles;

    private Vector3 _position;

    private void Start()
    {
        _position = _target.InverseTransformPoint(transform.position);
    }

    private void FixedUpdate()
    {
        var oldRotation = _target.rotation;
        _target.rotation = Quaternion.Euler(0, oldRotation.eulerAngles.y, 0);
        var currentPosition = _target.TransformPoint(_position);
        _target.rotation = oldRotation;

        transform.position = Vector3.Lerp(transform.position, currentPosition, _cameraSpeed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(_target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, _cameraSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(_target.position, transform.position - _target.position, out hit, Vector3.Distance(transform.position, _target.position), _maskObstacles))
        {
            transform.position = hit.point;
            transform.LookAt(_target);
        }
    }
}
