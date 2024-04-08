using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(BotMover))]
public class BotTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _stopDistance;

    private Transform _transform;
    private BotMover _move;

    private void Awake()
    {
        _move = GetComponent<BotMover>();
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_transform.position, _target.position) > _stopDistance)
        {
            _move.Move((_target.position - _transform.position).normalized);
        }
        else
        {
            _move.Move(Vector3.zero);
        }
        
    }
}
