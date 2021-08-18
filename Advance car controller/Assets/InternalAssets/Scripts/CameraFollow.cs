using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private float _translationSpeed;
    [SerializeField] private float _rotationSpeed;

    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    void HandleTranslation()
    {
        Vector3 targetPosition = _target.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _translationSpeed * Time.deltaTime);

    }

    void HandleRotation()
    {
        var direction = _target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
