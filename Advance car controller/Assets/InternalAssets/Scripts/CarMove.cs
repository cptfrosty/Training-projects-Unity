using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMove : MonoBehaviour
{
    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";

    private float _horizontalInput; //Горизонтальный ввод
    private float _verticalInput; //Вертикальный ввод
    private float _currentSteeringAngle; //Текущий угол поворота колеса
    private float _currentBreakingForce; //Сила торможения
    private bool _isBreaking; //Торможение

    [SerializeField] private float _motorForce; //Двигательная сила
    [SerializeField] private float _breakForce; //Остановочная сила
    [SerializeField] private float _maxSteerAngle; //Максимальный угол поворота

    [Space]
    [Header("Wheel Collides:")]
    [SerializeField] WheelCollider _frontLeftWheelCollider;  //Переднее левое колесо
    [SerializeField] WheelCollider _frontRightWheelCollider; //Переднее правое колесо
    [SerializeField] WheelCollider _backLeftWheelCollider;  //Заднее левое колесо
    [SerializeField] WheelCollider _backRightWheelCollider; //Заднее правое колесо

    [Space]
    [Header("Wheel Transforms:")]
    [SerializeField] Transform _frontLeftTransform;  //Переднее левое колесо
    [SerializeField] Transform _frontRightTransform; //Переднее правое колесо
    [SerializeField] Transform _backLeftTransform;  //Заднее левое колесо
    [SerializeField] Transform _backRightTransform; //Заднее правое колесо


    private void FixedUpdate()
    {
        GetInput(); //Считывание входных данных
        HandlerMotor(); //Управление двигателем
        HandlerSteering(); //Рулевое управление
        UpdateWheels(); //Обновление колёс
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis(_HORIZONTAL);
        _verticalInput = Input.GetAxis(_VERTICAL);
        _isBreaking = Input.GetKey(KeyCode.Space);
    }

    void HandlerMotor()
    {
        //motorTorque - крутящий момент двигателя
        _frontLeftWheelCollider.motorTorque = _verticalInput * _motorForce;
        _frontRightWheelCollider.motorTorque = _verticalInput * _motorForce;
        //_backLeftWheelCollider.motorTorque = _verticalInput * _motorForce;
        //_backRightWheelCollider.motorTorque = _verticalInput * _motorForce;

        _currentBreakingForce = _isBreaking ? _breakForce : 0f;

        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        _frontRightWheelCollider.brakeTorque = _currentBreakingForce;
        _frontLeftWheelCollider.brakeTorque = _currentBreakingForce;
        _backRightWheelCollider.brakeTorque = _currentBreakingForce;
        _backLeftWheelCollider.brakeTorque = _currentBreakingForce;
    }

    void HandlerSteering()
    {
        _currentSteeringAngle = _maxSteerAngle * _horizontalInput;
        _frontLeftWheelCollider.steerAngle = _currentSteeringAngle;
        _frontRightWheelCollider.steerAngle = _currentSteeringAngle;
    }

    void UpdateWheels()
    {
        UpdateSingleWheels(_frontLeftWheelCollider, _frontLeftTransform);
        UpdateSingleWheels(_frontRightWheelCollider, _frontRightTransform);
        UpdateSingleWheels(_backLeftWheelCollider, _backLeftTransform);
        UpdateSingleWheels(_backRightWheelCollider, _backRightTransform);
    }

    void UpdateSingleWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
