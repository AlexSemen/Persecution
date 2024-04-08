using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityFactor;

    [Header("Ground Check")]
    [SerializeField] private float _groundRadius;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    [Header("Stair Climb")]
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] float stepRayUpperLength;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepRayLowerLength;
    [SerializeField] float stepHeight;
    [SerializeField] float stepSmooth;

    private Rigidbody _rigidbody;
    private bool _isGrounded;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepRayLower.transform.position.y + stepHeight, stepRayUpper.transform.position.z);
    }

    public void Move(Vector3 vector3)
    {
        if (_rigidbody != null && _groundCheck == null)
            throw new NullReferenceException();

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);

        if (_isGrounded)    
        {
            if (Mathf.Approximately(vector3.x, 0) && Mathf.Approximately(vector3.z, 0))
            {
                _rigidbody.velocity = Vector3.zero;
            }
            else
            {
                _rigidbody.velocity = vector3 * _speed;
                _rigidbody.velocity += Physics.gravity * _gravityFactor;

                float Angle = Mathf.Atan2(vector3.x, vector3.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, Angle, 0);

                ClimbStep();
            }
        }
        else
        {
            _rigidbody.velocity += Physics.gravity * _gravityFactor;
        }
    }

    private void ClimbStep()
    {
        RaycastHit hitLower;
        if (Physics.Linecast(stepRayLower.transform.position, stepRayLower.transform.position + stepRayLower.transform.forward * stepRayLowerLength, out hitLower, _groundMask))
        {
            RaycastHit hitUpper;
            if (!Physics.Linecast(stepRayUpper.transform.position, stepRayUpper.transform.position + stepRayUpper.transform.forward * stepRayUpperLength, out hitUpper, _groundMask))
            {
                _rigidbody.position += new Vector3(0f, stepSmooth, 0f);
            }
        }
    }
}
