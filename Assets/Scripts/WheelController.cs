using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] Rigidbody rbCar;

    public float accel = 500f;
    public float breakingForce = 300f;
    public float fullBreakingForce = 600;
    public float lightBreakingForce = 200;
    public float maxTurnAngle = 30f;
    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;
    private void Awake()
    {
        rbCar = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        currentAcceleration = accel * Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
        }
        else if(Input.GetKey(KeyCode.B))
        {
            currentBreakForce = fullBreakingForce;
        }
        else if(Input.GetKey(KeyCode.C))
        {
            currentBreakForce = lightBreakingForce;
        }
        else
        {
            currentBreakForce = 0;
        }
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;
        backRight.motorTorque = currentAcceleration;


        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        Debug.Log("Speed: " + rbCar.velocity.magnitude*3.6f); 
    }

}
