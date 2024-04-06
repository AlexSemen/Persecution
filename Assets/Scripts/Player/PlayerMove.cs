using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityFactor;

    private CharacterController _controller;
    private Transform _transform;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _transform = transform;
    }
   
    public void Move(Vector3 playerImput)
    {
        if (_controller != null)
        {
            playerImput *= _speed;

            if (_controller.isGrounded)
            {
                _controller.Move(playerImput + Vector3.down);
            }
            else
            {
                _controller.Move(_controller.velocity + Physics.gravity * _gravityFactor);
            }

        }
    }
}
