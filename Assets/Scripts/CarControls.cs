using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Rename the terms used in the Unity physics engine
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float HorizonalInput;
    private float VerticalInput;
    private float currentbreakForce;
    private float steerAngle;
    // Choose whether to break or not
    private bool IsBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    // SerializeField is because we don't want other scripts to access it, but we do in the inspector
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;

    [SerializeField] private Transform RearRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform FrontLeftWheelTransform;

    // We use "FixedUpdate" because we need to use the Unity physics engine
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheel();
    }

    private void GetInput()
    {
        HorizonalInput = Input.GetAxis(HORIZONTAL);
        VerticalInput = Input.GetAxis(VERTICAL);
        IsBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        FrontLeftWheelCollider.motorTorque = VerticalInput * motorForce;
        FrontRightWheelCollider.motorTorque = VerticalInput * motorForce;
        currentbreakForce = IsBreaking ? breakForce : 0f;
        if (IsBreaking)
        {
            ApplyBreaking();
        }

    }

    private void ApplyBreaking()
    {
        FrontRightWheelCollider.brakeTorque = currentbreakForce;
        FrontLeftWheelCollider.brakeTorque = currentbreakForce;
        RearRightWheelCollider.brakeTorque = currentbreakForce;
        RearLeftWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        steerAngle = maxSteerAngle * HorizonalInput;
        FrontLeftWheelCollider.steerAngle = steerAngle;
        FrontRightWheelCollider.steerAngle = steerAngle;
    }

    private void UpdateWheel()
    {
        UpdateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheel(RearRightWheelCollider, RearRightWheelTransform);
        UpdateSingleWheel(RearLeftWheelCollider, RearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;

    }



}