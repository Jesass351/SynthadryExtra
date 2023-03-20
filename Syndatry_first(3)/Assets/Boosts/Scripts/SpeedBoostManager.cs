using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostManager : MonoBehaviour
{
    public bool hasBoost;

    private CustomCharacterController _characterController;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _boostTime;

    private float _previousWalkingSpeed;
    private float _previousRunningSpeed;
    private float _timer = 0f;
    void Start()
    {
        _characterController = GetComponent<CustomCharacterController>();
        hasBoost = false;
        _previousRunningSpeed = _characterController.runningSpeed;
        _previousWalkingSpeed = _characterController.walkingSpeed;
    }

    void Update()
    {
        if (hasBoost)
        {
            if (_characterController.walkingSpeed != _previousWalkingSpeed + _speed && _characterController.runningSpeed != _previousRunningSpeed + _speed)
            {
                _previousRunningSpeed = _characterController.runningSpeed;
                _previousWalkingSpeed = _characterController.walkingSpeed;
                _characterController.runningSpeed += _speed;
                _characterController.walkingSpeed += _speed;
            }    

            _timer += Time.deltaTime;
            if (_timer >= _boostTime)
            {
                hasBoost = false;
                _timer = 0f;
                _characterController.walkingSpeed = _previousWalkingSpeed;
                _characterController.runningSpeed = _previousRunningSpeed;
            }
        } 
    }
}
