using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] float _speed;

    private void Start()
    {
        _controller= GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");
        _controller.Move(direction * _speed * Time.deltaTime);
    }


}
