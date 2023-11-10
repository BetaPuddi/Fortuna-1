using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AICarDrive : MonoBehaviour
{
    private float steerAngle;
    private float currentBreakForce;

    [SerializeField] public float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform rearRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;

    [SerializeField] private Transform[] waypoints;
    private int currentWaypoint = 0;

    private InputActionAsset inputActionAsset;

    private InputAction moveAction;
    private InputAction brakeAction;

    private void FixedUpdate()
    {
        HandleNavigation();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleNavigation()
    {
        Transform currentWaypointTransform = waypoints[currentWaypoint];
        if (Vector3.Distance(transform.position, currentWaypointTransform.position) < 5)
        {
            currentWaypointTransform = waypoints[++currentWaypoint];
        }
        Vector3 relativeWaypointTransform = transform.InverseTransformPoint(currentWaypointTransform.position);
        relativeWaypointTransform.y = 0;
        steerAngle = Mathf.Clamp(Vector3.SignedAngle(Vector3.forward, relativeWaypointTransform, Vector3.up), -maxSteerAngle, maxSteerAngle);
    }

    private void HandleMotor()
    {
        float motorTorque = motorForce;

        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;

        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
