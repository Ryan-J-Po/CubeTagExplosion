using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _moveDirection;

    public float Acceleration;
    public float MaxSpeed;
    public float JumpPower;
    public float AirAccelerationReduction = 2;
    public GroundColliderBehaviour GroundCollider;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    public void Jump()
    {
        if (GroundCollider.IsGrounded)
        {
            _rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float acceleration = Acceleration;

        if (!GroundCollider.IsGrounded)
        {
            acceleration /= AirAccelerationReduction;
        }

        _rb.AddForce(_moveDirection * acceleration * Time.deltaTime, ForceMode.VelocityChange);
        
        if (_rb.velocity.magnitude > MaxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * MaxSpeed;
        }
    }
}
