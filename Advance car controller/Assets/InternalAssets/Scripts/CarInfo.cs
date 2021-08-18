using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInfo : MonoBehaviour
{
    [SerializeField] private Car _currentCar;

    [SerializeField] private Text speedCar;

    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = _currentCar.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        UpdateSpeedCar(_rigidbody.velocity.magnitude);
    }

    private void UpdateSpeedCar(float value)
    {
        speedCar.text = value.ToString("0");
    }
}
