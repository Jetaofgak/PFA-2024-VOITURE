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
    public bool LeftRightBool = false;
    public float LeftOrRightDir = 0;
    public float UpOrDownDir = 0;
    public bool UpDownBool = false;
    public bool Lbreak = false;
    public bool Fbreak = false;
    public bool breaking = false;
   
    private void Awake()
    {
        rbCar = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Debug.Log("Brake level: "+frontLeft.brakeTorque);
        if(LeftRightBool)
        {

            LeftOrRight(LeftOrRightDir);
            LeftRightBool = false;
        }
        else
        {
            
        }

        if(UpDownBool)
        {
            ForwardOrBackward(UpOrDownDir);
            UpDownBool = false;
        }
        else
        {
            
        }

        if(Lbreak)
        {
            Debug.Log("BL");
            ApplyLightBreak();
            Lbreak =false;
        }
        else if(breaking)
        {
            
            
            Debug.Log("BB");
            ApplyFullBreak();
            breaking =false;
        }
        else if(Fbreak)
        {
           
            
            Debug.Log("FB");
            ApplyBaseBreak();
            Fbreak =false;
        }
        else
        {
                BreakZero();
        }
        Debug.Log("Speed: " + rbCar.velocity.magnitude);
        
    }
    public void BreakZero()
    {
        frontRight.brakeTorque = 0;
        frontLeft.brakeTorque = 0;
        backRight.brakeTorque = 0;
        backLeft.brakeTorque = 0;
    }
    public void LeftOrRight(float dir)
    {
        currentTurnAngle = maxTurnAngle * dir;
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
        

    }

    public void ForwardOrBackward(float move)
    {
        currentAcceleration = accel * move;
        
        AccelAndBreak();
    }
    public void AccelAndBreak()
    {

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;
        backRight.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
    }
    public void ApplyLightBreak()
    {
        currentBreakForce = lightBreakingForce;
        AccelAndBreak();
    }

    public void ApplyBaseBreak()
    {
        currentBreakForce = breakingForce;
        AccelAndBreak();
    }

    public void ApplyFullBreak()
    {
        currentBreakForce = fullBreakingForce;
        AccelAndBreak();
    }
}
