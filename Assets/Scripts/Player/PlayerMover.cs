using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityFactor;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
