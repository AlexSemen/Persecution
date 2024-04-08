using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerImput : MonoBehaviour
{
    private PlayerMover _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMover>();
    }

    private void FixedUpdate()
    {
        _playerMove.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
