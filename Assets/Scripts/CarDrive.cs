using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour

{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;
    public WheelCollider flwCollider;
    public WheelCollider frwCollider;
    public WheelCollider rlwCollider;
    public WheelCollider rrwCollider;
    public Transform flwTransform;
    public Transform frwTransform;
    public Transform rlwTransform;
    public Transform rrwTransform;
    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;
    private void FixedUpdate()
    {


        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();


    }
    private void GetInput()

    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleSteering()

    {
        steerAngle = maxSteeringAngle * horizontalInput;

        flwCollider.steerAngle = steerAngle;
        frwCollider.steerAngle = steerAngle;
    }
    private void HandleMotor()

    {
        flwCollider.motorTorque = verticalInput * motorForce;
        frwCollider.motorTorque = verticalInput * motorForce;


        brakeForce = isBreaking ? 3000f : 0f;
        flwCollider.brakeTorque = brakeForce;
        frwCollider.brakeTorque = brakeForce;
        rlwCollider.brakeTorque = brakeForce;
        rrwCollider.brakeTorque = brakeForce;

    }
    private void UpdateWheels()

    {
        UpdateWheelPos(flwCollider, flwTransform);
        UpdateWheelPos(frwCollider, frwTransform);
        UpdateWheelPos(rlwCollider, rlwTransform);
        UpdateWheelPos(rrwCollider, rrwTransform);

    }
    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)

    {

        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;

    }
}
