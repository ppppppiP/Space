using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] float _speed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _speedUp;
    
    float _horizontal;

    private void Start()
    {
        _controller= GetComponent<CharacterController>();

     
    }

    private void Update()
    {
        
        Vector3 direction = Vector3.right * SimpleInput.GetAxis("Horizontal");
       _controller.Move(direction * _speed * Time.deltaTime);
        if (_speed < _maxSpeed)
            _speed += _speedUp * Time.deltaTime;
    }

  


}
