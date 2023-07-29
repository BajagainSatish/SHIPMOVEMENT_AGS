using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoat : MonoBehaviour
{
    [SerializeField] private Transform Motor;
    [SerializeField] private float steerPower = 10000f;
    [SerializeField] private float power = 700f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float drag = 10f;
    [SerializeField] private Joystick joystick;

    private Rigidbody _rigidbody;
    private Vector3 forward;
    private float steer;
    private bool movingForward;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Boat Rotation
        Vector2 input = new Vector2(joystick.Horizontal,joystick.Vertical);
        Vector2 inputDir = input.normalized;
        if(inputDir != Vector2.zero)
        {
        transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x,inputDir.y) * Mathf.Rad2Deg;
        }

        //steer direction
        if (joystick.Horizontal >= .2f)
        {
            steer = -1;//right steer
        }
        else if (joystick.Horizontal <= -.2f)
        {
            steer = 1;//left steer
        }
        else
        {
            steer = 0;//forward
        }

        //Rotational force
        _rigidbody.AddForceAtPosition(steer * steerPower * transform.right / 100f, Motor.position);

        //Compute vectors
        //forward = Vector3.Scale(new Vector3(1,0,1),transform.forward);

        //forward and backward power
        if (joystick.Vertical >= .2f || joystick.Vertical <= -.2f)
        {
            ApplyForceToReachVelocity(_rigidbody, transform.forward * maxSpeed, power);
        }

        // moving forward
        movingForward = Vector3.Cross(transform.forward, _rigidbody.velocity).y < 0;

        //move in direction
        _rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(_rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * drag, Vector3.up) * _rigidbody.velocity;
    }
    private void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
    {
        if (force == 0 || velocity.magnitude == 0)
            return;

        velocity = velocity + velocity.normalized * 0.2f * rigidbody.drag;

        //force = 1 => need 1 s to reach velocity (if mass is 1) => force can be max 1 / Time.fixedDeltaTime
        force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);

        //dot product is a projection from rhs to lhs with a length of result / lhs.magnitude https://www.youtube.com/watch?v=h0NJK4mEIJU
        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(velocity * force, mode);
        }
        else
        {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }
}
