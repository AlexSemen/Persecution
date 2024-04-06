using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControler : MonoBehaviour
{
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void FixedUpdate()
    {
        _playerMove.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
